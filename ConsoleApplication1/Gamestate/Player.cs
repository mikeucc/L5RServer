using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class Player
    {

        #region Variables
        public Battlefield currentBattlefield { get; set; }
        public Stronghold stronghold { get; set; }
        public int maxHandSize { get; set; } // other cards both your own and opponents can modify this
        public int startingHandSize;
        public int goldPool { get; set; }
        public int familyHonour { get; set; }
        public bool isAttacking { get; set; }
        public Player opposingPlayer { get; set; }
        public Gamestate gs { get; set; }
        public bool hasPassed { get; set; }
        public bool InterruptHasPassed { get; set; }
        public List<Province> playerProvinces { get; private set; }
        public List<Card> playerAbilities { get; set; }
        public bool firstTurn;
        public bool hasImperialFavour;
        public string aLabel { get; set; }

        public PlayerDynastyDeck pDynastyDeck;
        public PlayerDynastyDiscard pDynastyDiscard;
        public PlayerFateDeck pFateDeck;
        public PlayerFateDiscard pFateDiscard;
        public PlayerHand pHand;
        public PlayerHome pHome;


        
        //This will be replced by an object, like fatedeck hand etc
        public List<Card> cardsInPlay
        {
            get;
            set;
        }

       #endregion

        #region Player setup
        public Player()
        {
            
            this.cardsInPlay = new List<Card>();

            //Initilse play area's
            pHand = new PlayerHand();
            pFateDeck = new PlayerFateDeck();
            pFateDiscard = new PlayerFateDiscard();
            pDynastyDeck = new PlayerDynastyDeck();
            pDynastyDiscard = new PlayerDynastyDiscard();
            pHome = new PlayerHome();

            //Set starting Variables
            this.maxHandSize = 8; //Max hand size is varible but default is 8
            this.goldPool = 0;
            this.isAttacking = false;
            this.firstTurn = false;
            this.hasImperialFavour = false;
        }

        public void setPlayerDeck(List<FateCard> fd, List<DynastyCard> dd, Stronghold sh)
        {
            
            pFateDeck.addFateCards(fd);
            pHand.addCardToHand(pFateDeck.drawTopCard());
            pHand.addCardToHand(pFateDeck.drawTopCard());
            pHand.addCardToHand(pFateDeck.drawTopCard());


            this.pDynastyDeck.addCardsToDeck(dd);
            this.stronghold = sh;

            playerProvinces = new List<Province>();

            for (int i = 0; i < stronghold.numOfStartingProvinces; i++)
            {
                playerProvinces.Add(new Province(this));
            }      
        }

        public void fillProvinces()
        {
            foreach (Province prov in playerProvinces)
            {
                prov.purchasableCard = this.pDynastyDeck.drawTopCard();
            }
        }
        #endregion

        #region Player Abilities
        public void setPlayerAbilities()
        {
            this.playerAbilities = new List<Card>();
            this.opposingPlayer = gs.getOpposingPlayer(this);



            // Limited/open Pass
            PlayerOpenPass tempCard = new PlayerOpenPass();
            tempCard.createCard(this);
            this.playerAbilities.Add(tempCard);
            

            //Interrupt Pass
            PlayerInterruptPass tempCard2 = new PlayerInterruptPass();
            tempCard2.createCard(this);
            this.playerAbilities.Add(tempCard2);


            //Dynasty Pass
            PlayerDynastyPass tempCard3 = new PlayerDynastyPass();
            tempCard3.createCard(this);
            this.playerAbilities.Add(tempCard3);

            
            //Battlefield Pass
            PlayerBattlePass tempCard4 = new PlayerBattlePass();
            tempCard4.createCard(this);
            this.playerAbilities.Add(tempCard4);
            

            //Recruit Interrupt Pass
            PlayerRecruitInterruptPass tempCard5 = new PlayerRecruitInterruptPass();
            tempCard5.createCard(this);
            this.playerAbilities.Add(tempCard5);

            //Turn 1 cycle
            PlayerLimitedCycle tempcard6 = new PlayerLimitedCycle();
            tempcard6.createCard(this);
            this.playerAbilities.Add(tempcard6);

            PlayerLimitedImperialFavour tempcard7 = new PlayerLimitedImperialFavour();
            tempcard7.createCard(this);
            this.playerAbilities.Add(tempcard7);

            PlayerOpenEquip tempCard8 = new PlayerOpenEquip();
            PlayerDynastyRecruit tempCard9 = new PlayerDynastyRecruit();
            PlayerLimitedLobby tempCard10 = new PlayerLimitedLobby();
            PlayerDynastyRefill tempcard11 = new PlayerDynastyRefill();

            tempCard8.createCard(this);
            tempCard9.createCard(this);
            tempCard10.createCard(this);
            tempcard11.createCard(this);

            this.playerAbilities.Add(tempCard8);
            this.playerAbilities.Add(tempCard9);
            this.playerAbilities.Add(tempCard10);
            this.playerAbilities.Add(tempcard11);
            
            
        }
#endregion

        #region Perform actions

        public IAction pickAction(List<IAction> abilityList)
        {
            IAction pickedAction = gs.pickAbility(abilityList,this);

            return pickedAction;
        }

        public void performAction(IAction action)
        {
            Console.WriteLine("Perform action called");
            action.announceAction();
            action.payActionCosts();
            action.playInterrupts();
            action.resolveEffects();

        }

        public void performInterrupt(IAction interrupt)
        {
            interrupt.announceAction();
            interrupt.payActionCosts();
            interrupt.resolveEffects();
        }



        public IAction pickInterrupt(List<IAction> interruptList)
        {
            IAction pickedInterrupt = gs.pickAbility(interruptList,this);
            return pickedInterrupt;
        }
        #endregion

        #region Get Legal actions methods
        public List<IAction> getActionRecruitInterrupt()
        {
            List<IAction> returnList = new List<IAction>();

            foreach (Holding crd in this.cardsInPlay)
            {
                foreach (ActionRecruitInterrupt ari in crd.recruitInterrupts)
                {
                    returnList.Add(ari);
                }
            }

            foreach (Personality crd in this.cardsInPlay)
            {
                foreach (ActionRecruitInterrupt ari in crd.recruitInterrupts)
                {
                    returnList.Add(ari);
                }
                foreach(Attachment att in crd.getAllAttachedCards())
                {
                    foreach (ActionRecruitInterrupt ari in att.recruitInterrupts)
                    {
                        returnList.Add(ari);
                    }
                }

            }
            foreach (PlayerCard plc in this.playerAbilities)
            {
                foreach (ActionRecruitInterrupt ari in plc.cardAbilities)
                {
                    returnList.Add(ari);
                }
            }

            
            return returnList;

        }


        //create and set the list of legal cards from hand
        public void setLegalCardsInHand()
        {
            List<IAction> actionsThatcanBeplayed = new List<IAction>();
            foreach (Strategy str in this.pHand.getCardsInHand())
            {
                foreach (IAction ab in str.cardAbilities)
                {
                    //Is the action Limited open or Limied/Open
                    if ((ab is ActionLimited || ab is ActionLimitedPolitical || ab is ActionLimitedReapatable || ab is ActionOpen || ab is ActionOpenRepeatable || ab is ActionOpenRepeatableTireless || ab is ActionOpenTireless || ab is ActionBattle || ab is ActionAbsentBattle || ab is ActionBattleRepeatable || ab is ActionBattleTireless || ab is ActionBattleTirelessRepeatable || ab is ActionHomeBattle || ab is ActionDynasty || ab is ActionDynastyRepeatable||ab is ActionInterrupt) && ab.canBePerformed())
                        actionsThatcanBeplayed.Add(ab);
                }
            }

            if (this.Equals(gs.activePlayer))
            {
                gs.activeLegalActionsFromHand = actionsThatcanBeplayed;
            }
            else
            {
                gs.inactiveLegalActionsFromHand = actionsThatcanBeplayed;
            }

        }

        public void setLegalCardsInPlay()
        {
            List<IAction> actionsThatcanBeplayed = new List<IAction>();

            //Holding abilities
            foreach (Holding hld in this.cardsInPlay)
            {
                foreach (IAction ab in hld.cardAbilities)
                {
                    //Is the action Limited open or Limied/Open
                    if ((ab is ActionLimited || ab is ActionLimitedPolitical || ab is ActionLimitedReapatable || ab is ActionOpen || ab is ActionOpenRepeatable || ab is ActionOpenRepeatableTireless || ab is ActionOpenTireless || ab is ActionBattle || ab is ActionAbsentBattle || ab is ActionBattleRepeatable || ab is ActionBattleTireless || ab is ActionBattleTirelessRepeatable || ab is ActionHomeBattle || ab is ActionDynasty || ab is ActionDynastyRepeatable || ab is ActionInterrupt) && ab.canBePerformed())
                        actionsThatcanBeplayed.Add(ab);
                }
            }

            //Event abilities
            foreach (EventCard evn in this.cardsInPlay)
            {
                foreach (IAction ab in evn.cardAbilities)
                {
                    //Is the action Limited open or Limied/Open
                    if ((ab is ActionLimited || ab is ActionLimitedPolitical || ab is ActionLimitedReapatable || ab is ActionOpen || ab is ActionOpenRepeatable || ab is ActionOpenRepeatableTireless || ab is ActionOpenTireless || ab is ActionBattle || ab is ActionAbsentBattle || ab is ActionBattleRepeatable || ab is ActionBattleTireless || ab is ActionBattleTirelessRepeatable || ab is ActionHomeBattle || ab is ActionDynasty || ab is ActionDynastyRepeatable || ab is ActionInterrupt) && ab.canBePerformed())
                        actionsThatcanBeplayed.Add(ab);
                }
            }

            //Strategies (AKA kata's)
            foreach (Strategy str in this.cardsInPlay)
            {
                foreach (IAction ab in str.cardAbilities)
                {
                    //Is the action Limited open or Limied/Open
                    if ((ab is ActionLimited || ab is ActionLimitedPolitical || ab is ActionLimitedReapatable || ab is ActionOpen || ab is ActionOpenRepeatable || ab is ActionOpenRepeatableTireless || ab is ActionOpenTireless || ab is ActionBattle || ab is ActionAbsentBattle || ab is ActionBattleRepeatable || ab is ActionBattleTireless || ab is ActionBattleTirelessRepeatable || ab is ActionHomeBattle || ab is ActionDynasty || ab is ActionDynastyRepeatable || ab is ActionInterrupt) && ab.canBePerformed())
                        actionsThatcanBeplayed.Add(ab);
                }
            }

            if (this.Equals(gs.activePlayer))
            {
                gs.activeLegalActionsFromCardsAtHome = actionsThatcanBeplayed;
            }
            else
            {
                gs.activeLegalActionsFromCardsAtHome = actionsThatcanBeplayed;
            }
        }

        public void setLegalCardsFromUnits()
        {
            List<IAction> actionsThatcanBeplayed = new List<IAction>();

            //Get battle actions for cards at the current battlefield
            try
            {
                foreach (Personality per in gs.currentBattlefield.myCards(this))
                {
                    //Battle actions on personalities
                    foreach (IAction ab in per.cardAbilities)
                    {
                        if ((ab is ActionLimited || ab is ActionLimitedPolitical || ab is ActionLimitedReapatable || ab is ActionOpen || ab is ActionOpenRepeatable || ab is ActionOpenRepeatableTireless || ab is ActionOpenTireless || ab is ActionBattle || ab is ActionAbsentBattle || ab is ActionBattleRepeatable || ab is ActionBattleTireless || ab is ActionBattleTirelessRepeatable || ab is ActionHomeBattle || ab is ActionDynasty || ab is ActionDynastyRepeatable || ab is ActionInterrupt) && ab.canBePerformed())
                        {
                            actionsThatcanBeplayed.Add(ab);
                        }
                    }

                    //Get list of personality attachments
                    foreach (Attachment att in per.attachedCards)
                    {
                        //Get list of actions that can be played and add to list
                        foreach (IAction ab in att.cardAbilities)
                        {
                            if ((ab is ActionLimited || ab is ActionLimitedPolitical || ab is ActionLimitedReapatable || ab is ActionOpen || ab is ActionOpenRepeatable || ab is ActionOpenRepeatableTireless || ab is ActionOpenTireless || ab is ActionBattle || ab is ActionAbsentBattle || ab is ActionBattleRepeatable || ab is ActionBattleTireless || ab is ActionBattleTirelessRepeatable || ab is ActionHomeBattle || ab is ActionDynasty || ab is ActionDynastyRepeatable || ab is ActionInterrupt) && ab.canBePerformed())
                            {
                                actionsThatcanBeplayed.Add(ab);
                            }
                        }
                    }
                }
            }
            catch
            {
                //no battlefield
            }

            //Personalities
            foreach (Personality per in this.cardsInPlay)
            {
                //On the personality
                foreach (IAction ab in per.cardAbilities)
                {
                    //Is the action Limited open or Limied/Open
                    if ((ab is ActionLimited || ab is ActionLimitedPolitical || ab is ActionLimitedReapatable || ab is ActionOpen || ab is ActionOpenRepeatable || ab is ActionOpenRepeatableTireless || ab is ActionOpenTireless || ab is ActionBattle || ab is ActionAbsentBattle || ab is ActionBattleRepeatable || ab is ActionBattleTireless || ab is ActionBattleTirelessRepeatable || ab is ActionHomeBattle || ab is ActionDynasty || ab is ActionDynastyRepeatable || ab is ActionInterrupt) && ab.canBePerformed())
                        actionsThatcanBeplayed.Add(ab);
                }

                //On their attachments
                foreach (Attachment att in per.attachedCards)
                {
                    foreach (IAction ab in att.cardAbilities)
                    {
                        //Is the action Limited open or Limied/Open
                        if ((ab is ActionLimited || ab is ActionLimitedPolitical || ab is ActionLimitedReapatable || ab is ActionOpen || ab is ActionOpenRepeatable || ab is ActionOpenRepeatableTireless || ab is ActionOpenTireless || ab is ActionBattle || ab is ActionAbsentBattle || ab is ActionBattleRepeatable || ab is ActionBattleTireless || ab is ActionBattleTirelessRepeatable || ab is ActionHomeBattle || ab is ActionDynasty || ab is ActionDynastyRepeatable || ab is ActionInterrupt) && ab.canBePerformed())
                            actionsThatcanBeplayed.Add(ab);
                    }
                }
            }


            if (this.Equals(gs.activePlayer))
            {
                gs.activeLegalActionsFromUnits = actionsThatcanBeplayed;
            }
            else
            {
                gs.activeLegalActionsFromUnits = actionsThatcanBeplayed;
            }
        }

        public void setLegalCardfFromPlayerAbilities()
        {
            List<IAction> actionsThatcanBeplayed = new List<IAction>();

            foreach (PlayerCard crd in this.playerAbilities)
            {
                foreach (IAction ab in crd.cardAbilities)
                {//Is the action Limited open or Limied/Open
                    if ((ab is ActionLimited || ab is ActionLimitedPolitical || ab is ActionLimitedReapatable || ab is ActionOpen || ab is ActionOpenRepeatable || ab is ActionOpenRepeatableTireless || ab is ActionOpenTireless || ab is ActionBattle || ab is ActionAbsentBattle || ab is ActionBattleRepeatable || ab is ActionBattleTireless || ab is ActionBattleTirelessRepeatable || ab is ActionHomeBattle || ab is ActionDynasty || ab is ActionDynastyRepeatable || ab is ActionInterrupt) && ab.canBePerformed())
                        actionsThatcanBeplayed.Add(ab);
                }
            }



            if (this.Equals(gs.activePlayer))
            {
                gs.activeLegalActionsFromPlayerAbilities = actionsThatcanBeplayed;
            }
            else
            {
                gs.inactiveLegalActionsFromPlayerAbilities = actionsThatcanBeplayed;
            }
        }

        public void setLegalInterruptInHand()
        {
            List<IAction> interruptThatCanBePlayed = new List<IAction>();

            foreach (Strategy str in this.pHand.getCardsInHand())
            {
                foreach (IAction ab in str.cardAbilities)
                {
                    //Is the action Limited open or Limied/Open
                    if (ab is ActionInterrupt && ab.canBePerformed())
                    {
                        interruptThatCanBePlayed.Add(ab);
                    }
                }
            }

            if (this.Equals(gs.activePlayer))
            {
                gs.activeLegalActionsFromHand = interruptThatCanBePlayed;
            }
            else
            {
                gs.inactiveLegalActionsFromHand = interruptThatCanBePlayed;
            }
        }

        public void setLegalInterruptInPlay()
        {
            List<IAction> interruptThatCanBePlayed = new List<IAction>();

            foreach (Strategy str in this.cardsInPlay)
            {
                foreach (IAction ab in str.cardAbilities)
                {
                    //Is the action Limited open or Limied/Open
                    if (ab is ActionInterrupt && ab.canBePerformed())
                    {
                        interruptThatCanBePlayed.Add(ab);
                    }
                }
            }

            if (this.Equals(gs.activePlayer))
            {
                gs.activeLegalActionsFromCardsAtHome = interruptThatCanBePlayed;
            }
            else
            {
                gs.inactiveLegalActionsFromCardsAtHome = interruptThatCanBePlayed;
            }
        }

        public void setLegalInterruptFromUnits()
        {
            List<IAction> actionsThatcanBeplayed = new List<IAction>();

            //Get battle actions for cards at the current battlefield
            try
            {
                foreach (Personality per in gs.currentBattlefield.myCards(this))
                {
                    //Battle actions on personalities
                    foreach (IAction ab in per.cardAbilities)
                    {
                        if (ab is ActionInterrupt && ab.canBePerformed())
                        {
                            actionsThatcanBeplayed.Add(ab);
                        }
                    }

                    //Get list of personality attachments
                    foreach (Attachment att in per.attachedCards)
                    {
                        //Get list of actions that can be played and add to list
                        foreach (IAction ab in att.cardAbilities)
                        {
                            if (ab is ActionInterrupt && ab.canBePerformed())
                            {
                                actionsThatcanBeplayed.Add(ab);
                            }
                        }
                    }
                }
            }
            catch
            {
                //no battlefield
            }

            //Personalities
            foreach (Personality per in this.cardsInPlay)
            {
                //On the personality
                foreach (IAction ab in per.cardAbilities)
                {
                    //Is the action Limited open or Limied/Open
                    if (ab is ActionInterrupt && ab.canBePerformed())
                        actionsThatcanBeplayed.Add(ab);
                }

                //On their attachments
                foreach (Attachment att in per.attachedCards)
                {
                    foreach (IAction ab in att.cardAbilities)
                    {
                        //Is the action Limited open or Limied/Open
                        if (ab is ActionInterrupt && ab.canBePerformed())
                            actionsThatcanBeplayed.Add(ab);
                    }
                }
            }


            if (this.Equals(gs.activePlayer))
            {
                gs.activeLegalActionsFromUnits = actionsThatcanBeplayed;
            }
            else
            {
                gs.inactiveLegalActionsFromUnits = actionsThatcanBeplayed;
            }

        }

        public void setLegalInterruptFromPlayerAbilities()
        {
            List<IAction> actionsThatcanBeplayed = new List<IAction>();

            foreach (PlayerCard crd in this.playerAbilities)
            {
                foreach (IAction ab in crd.cardAbilities)
                {//Is the action Limited open or Limied/Open
                    if (ab is ActionInterrupt && ab.canBePerformed())
                        actionsThatcanBeplayed.Add(ab);
                }
            }

            if (this.Equals(gs.activePlayer))
            {
                gs.activeLegalActionsFromPlayerAbilities = actionsThatcanBeplayed;
            }
            else
            {
                gs.inactiveLegalActionsFromPlayerAbilities = actionsThatcanBeplayed;
            }
        }





        //Generate a list of legal Action phase actions
        //For the active player this is Limited and open actions
        public List<IAction> getActionListActionPhase()
        {

            List<IAction> actionsThatcanBeplayed = new List<IAction>();


            //player abilities aka pass, or mayby tactician

            foreach (PlayerCard crd in this.playerAbilities)
            {
                foreach (IAction ab in crd.cardAbilities)
                {//Is the action Limited open or Limied/Open
                    if ((ab is ActionLimited ||ab is ActionLimitedPolitical||ab is ActionLimitedReapatable||ab is ActionOpen||ab is ActionOpenRepeatable||ab is ActionOpenRepeatableTireless||ab is ActionOpenTireless)  && ab.canBePerformed())
                        actionsThatcanBeplayed.Add(ab);
                }
            }

            //Holding abilities
            foreach (Holding hld in this.cardsInPlay)
            {
                foreach (IAction ab in hld.cardAbilities)
                {
                    //Is the action Limited open or Limied/Open
                    if ((ab is ActionLimited || ab is ActionLimitedPolitical || ab is ActionLimitedReapatable || ab is ActionOpen || ab is ActionOpenRepeatable || ab is ActionOpenRepeatableTireless || ab is ActionOpenTireless) && ab.canBePerformed())
                        actionsThatcanBeplayed.Add(ab);
                }
            }

            //Event abilities
            foreach (EventCard evn in this.cardsInPlay)
            {
                foreach (IAction ab in evn.cardAbilities)
                {
                    //Is the action Limited open or Limied/Open
                    if ((ab is ActionLimited || ab is ActionLimitedPolitical || ab is ActionLimitedReapatable || ab is ActionOpen || ab is ActionOpenRepeatable || ab is ActionOpenRepeatableTireless || ab is ActionOpenTireless) && ab.canBePerformed())
                        actionsThatcanBeplayed.Add(ab);
                }
            }

            //Strategies (AKA kata's)
            foreach (Strategy str in this.cardsInPlay)
            {
                foreach (IAction ab in str.cardAbilities)
                {
                    //Is the action Limited open or Limied/Open
                    if ((ab is ActionLimited || ab is ActionLimitedPolitical || ab is ActionLimitedReapatable || ab is ActionOpen || ab is ActionOpenRepeatable || ab is ActionOpenRepeatableTireless || ab is ActionOpenTireless) && ab.canBePerformed())
                        actionsThatcanBeplayed.Add(ab);
                }
            }

            //Personalities
            foreach (Personality per in this.cardsInPlay)
            {
                //On the personality
                foreach (IAction ab in per.cardAbilities)
                {
                    //Is the action Limited open or Limied/Open
                    if ((ab is ActionLimited || ab is ActionLimitedPolitical || ab is ActionLimitedReapatable || ab is ActionOpen || ab is ActionOpenRepeatable || ab is ActionOpenRepeatableTireless || ab is ActionOpenTireless) && ab.canBePerformed())
                        actionsThatcanBeplayed.Add(ab);
                }

                //On their attachments
                foreach (Attachment att in per.attachedCards)
                {
                    foreach (IAction ab in att.cardAbilities)
                    {
                        //Is the action Limited open or Limied/Open
                        if ((ab is ActionLimited || ab is ActionLimitedPolitical || ab is ActionLimitedReapatable || ab is ActionOpen || ab is ActionOpenRepeatable || ab is ActionOpenRepeatableTireless || ab is ActionOpenTireless) && ab.canBePerformed())
                            actionsThatcanBeplayed.Add(ab);
                    }
                }
            }

            //Strategies in hand

            foreach (Strategy str in this.pHand.getCardsInHand())
            {
                foreach (IAction ab in str.cardAbilities)
                {
                    //Is the action Limited open or Limied/Open
                    if ((ab is ActionLimited || ab is ActionLimitedPolitical || ab is ActionLimitedReapatable || ab is ActionOpen || ab is ActionOpenRepeatable || ab is ActionOpenRepeatableTireless || ab is ActionOpenTireless) && ab.canBePerformed())
                        actionsThatcanBeplayed.Add(ab);
                }
            }
            
            //Return the list of abilities that can be performed
            //Abilites know their owner card, so can bow their owner if that is a cost
            Console.WriteLine("Actions that can be played"+actionsThatcanBeplayed.Count.ToString());
            return actionsThatcanBeplayed;
        }

       

        
        //Generate a list of legal actions
        //From cards at the current battlefield and cards at home
        //To do , cards at other battlefields
        public List<IAction> getActionListAtBattlefield(Battlefield bf)
        {
            List<IAction> actionsThatcanBeplayed = new List<IAction>();
            
            //player abilities aka pass, or mayby tactician

                foreach (PlayerCard crd in this.playerAbilities)
                {
                    foreach (IAction ab in crd.cardAbilities)
                    {
                        if ((ab is ActionBattle||ab is ActionAbsentBattle||ab is ActionBattleRepeatable||ab is ActionBattleTireless||ab is ActionBattleTirelessRepeatable||ab is ActionHomeBattle) && ab.canBePerformed())
                            actionsThatcanBeplayed.Add(ab);
                    }
                }

                //get battle actions in hand  
                foreach (Strategy crd in this.pHand.getCardsInHand())
                {
                    foreach(IAction ab in crd.cardAbilities)
                    {
                        if ((ab is ActionBattle || ab is ActionAbsentBattle || ab is ActionBattleRepeatable || ab is ActionBattleTireless || ab is ActionBattleTirelessRepeatable || ab is ActionHomeBattle) && ab.canBePerformed())
                        {
                            actionsThatcanBeplayed.Add(ab);   
                        }
                    }
                   
                }
                //Get battle actions for cards at the current battlefield
                foreach (Personality per in bf.myCards(this))
                {
                    //Battle actions on personalities
                    foreach (IAction ab in per.cardAbilities)
                    {
                        if ((ab is ActionBattle || ab is ActionAbsentBattle || ab is ActionBattleRepeatable || ab is ActionBattleTireless || ab is ActionBattleTirelessRepeatable || ab is ActionHomeBattle) && ab.canBePerformed())
                        {
                            actionsThatcanBeplayed.Add(ab);
                        }
                    }

                    //Get list of personality attachments
                    foreach (Attachment att in per.attachedCards)
                    {
                        //Get list of actions that can be played and add to list
                        foreach (IAction ab in att.cardAbilities)
                        {
                            if ((ab is ActionBattle || ab is ActionAbsentBattle || ab is ActionBattleRepeatable || ab is ActionBattleTireless || ab is ActionBattleTirelessRepeatable || ab is ActionHomeBattle) && ab.canBePerformed())
                            {
                                actionsThatcanBeplayed.Add(ab);
                            }
                        }
                    }
                }

                //Strategies
                foreach (Strategy crd in this.cardsInPlay)
                {
                    foreach (IAction ab in crd.cardAbilities)
                    {
                        if ((ab is ActionBattle || ab is ActionAbsentBattle || ab is ActionBattleRepeatable || ab is ActionBattleTireless || ab is ActionBattleTirelessRepeatable || ab is ActionHomeBattle) && ab.canBePerformed())
                        {
                            actionsThatcanBeplayed.Add(ab);
                        }
                    }
                }
                //Holdings
                foreach (Holding crd in this.cardsInPlay)
                {
                    foreach (IAction ab in crd.cardAbilities)
                    {
                        if ((ab is ActionBattle || ab is ActionAbsentBattle || ab is ActionBattleRepeatable || ab is ActionBattleTireless || ab is ActionBattleTirelessRepeatable || ab is ActionHomeBattle) && ab.canBePerformed())
                        {
                            actionsThatcanBeplayed.Add(ab);
                        }
                    }
                }
                //Rings
                foreach (Ring crd in this.cardsInPlay)
                {
                    foreach (IAction ab in crd.cardAbilities)
                    {
                        if ((ab is ActionBattle || ab is ActionAbsentBattle || ab is ActionBattleRepeatable || ab is ActionBattleTireless || ab is ActionBattleTirelessRepeatable || ab is ActionHomeBattle) && ab.canBePerformed())
                        {
                            actionsThatcanBeplayed.Add(ab);
                        }
                    }
                }

                foreach (Personality crd in this.cardsInPlay)
                {
                    foreach (IAction ab in crd.cardAbilities)
                    {
                        if ((ab is ActionHomeBattle) && ab.canBePerformed())
                        {
                            actionsThatcanBeplayed.Add(ab);
                        }
                    }
                }
           
            return actionsThatcanBeplayed;
        }


        public List<IAction> getListOfDynastyActions()
        {
            List<IAction> returnList=new List<IAction>();

            foreach (PlayerCard crd in this.playerAbilities)
            {
                foreach (IAction ab in crd.cardAbilities)
                {
                    if (ab.canBePerformed() && (ab is ActionDynasty||ab is ActionDynastyRepeatable))
                        returnList.Add(ab);
                }
            }

            return returnList;
        }

        public List<IAction> getListOfInterrupts(IAction actionToBePlayed, Battlefield currentBattlefield)
        {
            List<IAction> returnList = new List<IAction>();

            foreach (PlayerCard crd in this.playerAbilities)
            {
                foreach (IAction ab in crd.cardAbilities)
                {
                    //This will be pass
                    if (ab is ActionInterrupt && ab.canBePerformed())
                        returnList.Add(ab);
                }
            }
            
            
            
            //Action is not being played at a battle
            if (currentBattlefield == null)
            {
                //Cards in hand
                foreach (FateCard crd in pHand.getCardsInHand())
                {
                    if (crd is Strategy || crd is Ring)
                    {
                        foreach (IAction ab in crd.cardAbilities)
                        {
                            if (ab is ActionInterrupt && ab.canBePerformed())
                            {
                                returnList.Add(ab);
                            }
                        }
                    }
                }


                //Units in play
                foreach (Personality per in this.cardsInPlay)
                {
                    foreach (ActionInterrupt action in per.cardAbilities)
                    {
                        if (actionToBePlayed.isValidInterrupt(action)&&action.canBePerformed())
                        {
                            returnList.Add(action);
                        }
                    }

                    foreach (Attachment att in per.getAllAttachedCards())
                    {
                        foreach (ActionInterrupt action in att.cardAbilities)
                        {
                            if (actionToBePlayed.isValidInterrupt(action) && action.canBePerformed())
                            {
                                returnList.Add(action);
                            }
                        }
                    }
                }

                foreach (Holding hld in this.cardsInPlay)
                {
                    foreach (ActionInterrupt action in hld.cardAbilities)
                    {
                        if (actionToBePlayed.isValidInterrupt(action) && action.canBePerformed())
                        {
                            returnList.Add(action);
                        }
                    }
                }

                foreach (Strategy str in this.cardsInPlay)
                {
                    foreach (ActionInterrupt action in str.cardAbilities)
                    {
                        if (actionToBePlayed.isValidInterrupt(action) && action.canBePerformed())
                        {
                            returnList.Add(action);
                        }

                    }
                }
            }
            //Action is being played at a battlefield
            else
            {
                if (currentBattlefield.myCards(this).Count > 0)
                {

                    foreach (Strategy str in pHand.getCardsInHand())
                    {
                        foreach (ActionInterrupt action in str.cardAbilities)
                        {
                            if (actionToBePlayed.isValidInterrupt(action) && action.canBePerformed())
                            {
                                returnList.Add(action);
                            }

                        }
                    }

                    //Units in play
                    foreach (Personality per in currentBattlefield.myCards(this))
                    {
                        foreach (ActionInterrupt action in per.cardAbilities)
                        {
                            if (actionToBePlayed.isValidInterrupt(action) && action.canBePerformed())
                            {
                                returnList.Add(action);
                            }
                        }

                        foreach (Attachment att in per.getAllAttachedCards())
                        {
                            foreach (ActionInterrupt action in att.cardAbilities)
                            {
                                if (actionToBePlayed.isValidInterrupt(action) && action.canBePerformed())
                                {
                                    returnList.Add(action);
                                }
                            }
                        }
                    }
                }
            }


            return returnList;
        }
        #endregion

        #region Payment actions
        public void payGoldCost(int ammount)
        {
            if (ammount <= this.goldPool)
            {
                this.goldPool -= ammount;
            }
            else
            {
                this.addGoldToPool();
            }
        }

        public int ammountOfGoldAvailable()
        {
            int potentialGold = 0;
            //will also have to include potential gold available
            foreach (Holding hld in this.cardsInPlay)
            {
                if (hld.IsBowed == false)
                {
                    potentialGold += hld.goldProduction;
                }
            }


            return this.goldPool+potentialGold;
        }



        public void addGoldToPool()
        {
            //Some kind of GUI interface will do this

            // For testing purposes I have allowed gold to be added via the console
            Console.WriteLine("Gold in gold pool:" + this.goldPool);
            Console.WriteLine("How much gold to add to the pool");
            string input = Console.ReadLine();

            try
            {
                goldPool += Convert.ToInt32(input);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Input string is not a sequence of digits."+e.ToString());
            }

            // throw new NotImplementedException(); or throw CrapplyImplementedExceptio()

        }


        public bool canPlayerProduceGold(int ammountOfGold)
        {
            if (this.goldPool >= ammountOfGold)
            {
                return true;
            }

            if (this.goldPool + this.ammountOfGoldAvailable() > ammountOfGold)
            {
                return true;
            }

            return false;
        }
        #endregion

    }
}

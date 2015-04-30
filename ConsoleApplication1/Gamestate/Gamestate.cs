using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class Gamestate
    {
        #region Traits strings
        public static string Battle = "Battle";
        public static string Open = "Open";
        public static string Limited = "Limited";
        public static string Engage = "Engage";
        public static string Interrupt = "Interrupt";
        public static string BattleOpen = "BattleOpen";
        public static string HomeBattle = "HomeBattle";
        public static string LimitedOpen = "LimitedOpen";
        public static string DynastyInterrupt = "DynastyInterrupt";
        public static string AbsentBattle = "AbsentBatte";
        
        
        
        public static string Conqueror = "Conqueror";
        public static string Kensai = "Kensai";
        public static string Duelist = "Duelist";
        public static string Shugenja = "Shugenja";
        public static string Cavalry = "Cavalry";
        public static string Nonhuman = "Nonhuman";
        public static string Oni = "Oni";
        public static string Ring = "Ring";
        public static string Samurai = "Samurai";
        public static string Unique = "Unique";
        public static string Reserve = "Reserve";
        public static string Personality = "Personality";
        public static string Attachment = "Attachment";
        public static string Tactician = "Tactician";
        public static string Fallen = "Fallen";
        public static string Spirit = "Spirit";
        public static string Terrain = "Terrain";
        public static string Magistrate = "Magistrate";
        public static string Human = "Human";
        public static string Courtier = "Courtier";
        public static string Infantry = "Infantry";
        public static string Mountaineer = "Mountaineer";
        public static string Scout = "Scout";
        public static string Commander = "Commander";
        public static string Temple = "Temple";
        public static string Kharmic = "Kharmic";
        public static string Expendable = "Expendable ";
        public static string Destined = "Destined";
        public static string Courage = "Courage";
        public static string Resilient = "Resilient";
        public static string Imperial = "Imperial";
        public static string Market = "Market";
        public static string Mine = "Mine";
        public static string Port = "Port";

        


        public static string Earth = "Earth";
        public static string Air = "Air";
        public static string Water = "Water";
        public static string Fire = "Fire";
        public static string Void = "Void";
        public static string Thunder = "Thunder";



        public static string CrabClan = "Crab Clan";
        public static string CraneClan = "Crane Clan";
        public static string DragonClan = "Dragon Clan";
        public static string MantisClan = "Mantic Clan";
        public static string LionClan = "Lion Clan";
        public static string PhoenixClan = "Phoenix Clan";
        public static string SpiderClan = "Spider Clan";
        public static string ScorpionClan = "Scorpion Clan";
        public static string UnicornClan = "Unicorn Clan";
        public static string Unaligned = "Unaligned";

        #endregion

        #region variables
        public int turnCounter { get; set; }
        public Player player1 { get; set; }
        public Player player2 { get; set; }
        public Player activePlayer { get; set; }
        public Player inactivePlayer { get; set; }
        public Player performingPlayer { get; set; }
        
        public Battlefield currentBattlefield { get; set; }
        public List<Battlefield> unresolvedBattlefield { get; set; }
        public List<Battlefield> allBattlefields { get; set; }
        public Card currentActionBeingPlayedCard { get; set; }

        public IAction currentActionBeingPlayed { get; set; }
        public IAction currentInterruptBeingPlayed { get; set; }

        public ActionPhase actionPhase { get; set; }
        public AttackPhase attackPhase { get; set; }
        public DynastyPhase dynastyPhase { get; set; }

        public bool gameOver { get; set; }
        public bool isActionPhase { get; set; }
        public bool isBattlePhase { get; set; }
        public bool isDynastyPhase { get; set; }
        public bool activePassedRecruitInterrupt { get; set; }
        public bool inactivePassedRecruitInterrupt { get; set; }
        public bool activePlayerAction { get; set; }
        public bool inactivePlayerAction { get; set; }
        public bool activePlayerInterrupt { get; set; }
        public bool inactivePlayerInterrupt { get; set; }
        public bool actionCostsPaid { get; set; }
        public bool actionAnnounced { get; set; }
        public bool payingCosts { get; set; }
        public bool interruptsBeingPlayed { get; set; }
        public bool targetsBeingSelected { get; set; }
        public bool effectsResolving { get; set; }

        public List<IAction> activeLegalActionsFromHand { get; set; }
        public List<IAction> activeLegalActionsFromUnits { get; set; }
        public List<IAction> activeLegalActionsFromCardsAtHome { get; set; }
        public List<IAction> activeLegalActionsFromPlayerAbilities { get; set; }
        

        public List<IAction> inactiveLegalActionsFromHand { get; set; }
        public List<IAction> inactiveLegalActionsFromUnits { get; set; }
        public List<IAction> inactiveLegalActionsFromCardsAtHome { get; set; }
        public List<IAction> inactiveLegalActionsFromPlayerAbilities { get; set; }
        public List<IAction> legalActions { get; set; }

       

        public Gamestate(Player p1, Player p2)
        {

            this.turnCounter = 1;
            this.player1 = p1;
            player1.aLabel = "Player 1";
            this.player2 = p2;
            player2.aLabel = "Player 2";
            //place test to see who active player should be;
            this.activePlayer = p1;
            this.inactivePlayer = p2;
            this.performingPlayer = p1;

            this.gameOver = false;
            

            this.isActionPhase = true;
            this.isBattlePhase = false;
            this.isDynastyPhase = false;

            
            this.activePassedRecruitInterrupt = false;

            
            this.inactivePassedRecruitInterrupt = false;

            this.activePlayerAction = true;
            this.inactivePlayerAction = false;
            this.activePlayerInterrupt = false;
            this.inactivePlayerInterrupt = false;
            this.interruptsBeingPlayed = false;

            this.legalActions = new List<IAction>();

        }
        #endregion

        #region Performed Actions
        public void resolveInterrupt()
        {
            if (!currentInterruptBeingPlayed.Equals(null))
            {
                this.currentInterruptBeingPlayed.resolveEffects();
                this.currentInterruptBeingPlayed = null;
            }    
        }

        public void updateState()
        {
            if (isDynastyPhase)
            {
                Console.WriteLine("UpdateState:Dynasty Phase");
                if (this.dynastyPhase == null)
                {
                    Console.WriteLine("UpdateState:Creating new Dynasty phase");
                    dynastyPhase = new DynastyPhase(this);
                    this.activePlayer.hasPassed = false;
                    this.inactivePlayer.hasPassed = false;
                    this.activePlayerAction = true;
                    this.inactivePlayerAction = false;
                }


                dynastyPhase.performDynastyPhase();
                this.updateState();
            }
                
                
            // Not done correctly, need to be re written as event based (Currently using a while loop, will not work for 
            if (isBattlePhase)
            {
                Console.WriteLine("UpdateState:Battle Phase");
                if (attackPhase == null)
                {
                    attackPhase = new AttackPhase(activePlayer, inactivePlayer, this);
                }
            }
            
            if (isActionPhase)
            {
                Console.WriteLine("UpdateState:Action Phase");
                if (actionPhase == null)
                {
                    Console.WriteLine("UpdateState:Creating Action phase");
                    actionPhase = new ActionPhase(this);
                    actionPhase.startActionPhase();
                    this.player1.hasPassed = false;
                    this.player2.hasPassed = false;
                    this.player1.InterruptHasPassed = false;
                    this.player2.InterruptHasPassed = false;
                    this.activePlayerAction = true;
                    this.inactivePlayerAction = false;
                }

                actionPhase.performActionPhase();
                this.updateState();
            }
            

        }

        public void pickAction()
        {
            IAction selectedAction;
            for(int i=0;i<legalActions.Count;i++)
            {
                Console.WriteLine("Action Index:" + i.ToString() + " Action text:" + legalActions[i].displayActionText);
            }
            Console.Write("Select Action: ");
            try
            {
                selectedAction=legalActions[int.Parse(Console.ReadLine())];
                if(selectedAction.GetType().Equals(typeof(ActionInterrupt)))
                {
                    Console.WriteLine("Gamestate:Pick Action:Interrupt selected");
                    selectedAction.resolveEffects();
                    this.performingPlayer = performingPlayer.opposingPlayer;
                }
                else
                {
                    Console.WriteLine("Gamestate:Pick Action:Action selected");
                    this.interruptsBeingPlayed = true;
                    this.currentActionBeingPlayed = selectedAction;
                }
            }
            catch
            {
                Console.WriteLine("Invalid action selected");
            }
        }



        public Player getOpposingPlayer(Player p)
        {
            if(p.Equals(player1))
                return player2;
            else
                return player1;
        }


        /** Swaps active players
         */
        public void swapActivePlayer()
        {
            if (activePlayer == player1)
            {
                activePlayer = player2;
            }
            else
            {
                activePlayer = player1;
            }
        }

        public IAction pickAbility(List<IAction> abilityList,Player playerToSelect)
        {

            foreach (IAction ac in abilityList)
            {
                Console.WriteLine(ac.displayActionText);
            }

            Console.Write("Pick Ability: ");
            
            return abilityList[Int32.Parse(Console.ReadLine())];

            //GUI shit
        }

        public List<IEffect> pickEffects(List<IEffect> effectList, int numofEffects, Player playerToSelect)
        {
            return null;
            
            //GUI will do this
        }

        public IEffect pickEffect(List<IEffect> effectList,Player playerToSelect)
        {
            return null;
                //GUI will do this
        }

        public List<Card> pickTargets(List<Card> listOfLegalTargets,int numOfTargets,Player playerToSelect)
        {
            List<Card> returnList = new List<Card>();

            int i = numOfTargets;

            while (i > 0)
            {
                foreach (Card crd in listOfLegalTargets)
                {
                    Console.WriteLine("Card:" + crd.name);
                }
                Console.WriteLine("99= Done selecting");
                int j = int.Parse(Console.ReadLine());
                if (j == 99)
                {
                    Console.WriteLine("All targets selected");
                    break;
                }
                returnList.Add(listOfLegalTargets[j]);
                listOfLegalTargets.RemoveAt(j);
                i--;
            }

            
            return returnList;
            
            //GUI select
        }

        public Card pickTarget(List<Card> listOfLegalTargets, Player playerToSelect)
        {
            return listOfLegalTargets[0];
            //GUI will do this
        }

        public List<Province> pickProvinces(List<Province> listOfProvinces, int numOfTargets, Player playerToSelect)
        {
            return null;

            //GUI will select
        }

        public Province pickProvince(List<Province> listofProvinces, Player playerToSelect)
        {
            foreach (Province pv in listofProvinces)
            {
                Console.WriteLine("Province purchasable Card: " + pv.purchasableCard);
            }
            Console.WriteLine("Pick Province:");

            return listofProvinces[Int32.Parse(Console.ReadLine())];
            

        }

        public bool haveAttackPhase()
        {

            return false;

            //GUI will select this and give the real return value
        }

        public void createActiveActionList()
        {
            legalActions = new List<IAction>();

            if (performingPlayer.Equals(this.activePlayer))
            {

                foreach (IAction ac in this.activeLegalActionsFromHand)
                {
                    legalActions.Add(ac);
                }
                foreach (IAction ac in this.activeLegalActionsFromCardsAtHome)
                {
                    legalActions.Add(ac);
                }
                foreach (IAction ac in this.activeLegalActionsFromPlayerAbilities)
                {
                    legalActions.Add(ac);
                }
                foreach (IAction ac in this.activeLegalActionsFromUnits)
                {
                    legalActions.Add(ac);
                }
            }

            else
            {
                foreach (IAction ac in this.inactiveLegalActionsFromHand)
                {
                    legalActions.Add(ac);
                }
                foreach (IAction ac in this.inactiveLegalActionsFromCardsAtHome)
                {
                    legalActions.Add(ac);
                }
                foreach (IAction ac in this.inactiveLegalActionsFromPlayerAbilities)
                {
                    legalActions.Add(ac);
                }
                foreach (IAction ac in this.inactiveLegalActionsFromUnits)
                {
                    legalActions.Add(ac);
                }
            }

        }

        

        #endregion
    }

}


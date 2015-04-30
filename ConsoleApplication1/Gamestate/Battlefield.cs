using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class Battlefield
    {
        public List<Personality> attackingUnits;
        public List<Personality> defendingUnits;
        public Player attackingPlayer;
        public Player defendingPlayer;
        public Province battlefieldProvince;
        public bool isNaval;
        public Personality navalPersonality;


        public Battlefield(List<Personality> attackingUnits, Player attackingPlayer,List<Personality> defendingUnits,Player defendingPlayer,Province battlefieldProvince)
        {
            this.attackingUnits = attackingUnits;
            this.defendingUnits = defendingUnits;
            this.attackingPlayer = attackingPlayer;
            this.defendingPlayer = defendingPlayer;
            this.battlefieldProvince = battlefieldProvince;
            navalPersonality = null;
            this.isNaval = false;

        }

        public List<Personality> opposingCards(Player player)
        {
            if(player.Equals(attackingPlayer))
            {
                return defendingUnits;
            }
            else
            {
                return attackingUnits;
            }
        }

        public List<Personality> myCards(Player player)
        {
            if (player.Equals(attackingPlayer))
            {
                return attackingUnits;
            }
            else
            {
                return defendingUnits;
            }
        }

        public bool isCardHere(Player pl, Card crd)
        {
            foreach (Personality per in this.myCards(pl))
            {
                if (per.Equals(crd))
                {
                    return true;
                    
                }

                foreach (Attachment att in per.getAllAttachedCards())
                {
                    if (att.Equals(crd))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public Personality moveUnitToBattleField(Personality per)
        {
            return per;
        }

        public Personality removeUnitFromBattlefield(Personality per)
        {
            return per;
        }




        public void engagePhase()
        {

        }

        public void battlePhase()
        {
            //Is this a naval assault
            if (isNaval == true)
            {
                //Getting all legal actions that the naval unit can perform
                List<IAction> navalAbilityList = new List<IAction>();
                foreach (IAction ab in navalPersonality.cardAbilities)
                {
                    if (ab.canBePerformed())
                    {
                        navalAbilityList.Add(ab);
                    }
                }

                foreach (Attachment att in navalPersonality.getAllAttachedCards())
                {
                    foreach (IAction ab in att.cardAbilities)
                    {
                        if (ab.canBePerformed())
                        {
                            navalAbilityList.Add(ab);
                        }
                    }
                }

                //Send naval list to action perform
                attackingPlayer.performAction(attackingPlayer.pickAction(navalAbilityList));


                while (attackingPlayer.hasPassed == false && defendingPlayer.hasPassed == false)
                {
                    defendingPlayer.performAction(defendingPlayer.pickAction(defendingPlayer.getActionListAtBattlefield(this)));
                    attackingPlayer.performAction(attackingPlayer.pickAction(attackingPlayer.getActionListAtBattlefield(this)));
                }

            }
            else
            {
                while (attackingPlayer.hasPassed == false && defendingPlayer.hasPassed == false)
                {
                    defendingPlayer.performAction(defendingPlayer.pickAction(defendingPlayer.getActionListAtBattlefield(this)));
                    attackingPlayer.performAction(attackingPlayer.pickAction(attackingPlayer.getActionListAtBattlefield(this)));
                }
            }

        }

        public void resolutionPhase()
        {
            int defTotal=0;
            int attTotal=0;
            //Total up the army sizes.
            foreach (Personality attPer in attackingUnits)
            {
                attTotal += attPer.getUnitForce();
            }

            foreach (Personality defPer in defendingUnits)
            {
                defTotal += defPer.getUnitForce();
            }


            //Defending army wins
            if (defTotal > attTotal)
            {   int destroyedCards=0;
                //Count up the number of cards destroyed
                foreach (Personality attPer in attackingUnits)
                {
                    //Counts the personality
                    destroyedCards++;
                    //Then all its attached cards
                    destroyedCards += attPer.getAllAttachedCards().Count;
                    //Then destroy the card
                    attPer.destroyCard();
                }
                //Defending player then gains 2 honour per card 
                defendingPlayer.familyHonour += 2 * destroyedCards;

                //Move the defending units home
                foreach (Personality defPer in defendingUnits)
                {
                    defendingPlayer.cardsInPlay.Add(defPer);
                }
            }

            //Attacking army wins
            if (attTotal > defTotal)
            {
                int destroyedCards = 0;

                //Count up the number of destroyed cards
                foreach (Personality defPer in defendingUnits)
                {
                    //Counts the personality
                    destroyedCards++;
                    //Then all its attached cards
                    destroyedCards += defPer.getAllAttachedCards().Count;
                    //Then destroy the personality
                    defPer.destroyCard();
                }

                attackingPlayer.familyHonour += 2 * destroyedCards;

                foreach (Personality attPer in attackingUnits)
                {
                    if (attTotal - defTotal > battlefieldProvince.currentProvinceStrength)
                    {
                        //Check for conqueror units as they do not bow at resoluntion if province is destroyed
                        //Bow the personality
                        if (attPer.traits.Contains(L5R.Gamestate.Gamestate.Conqueror))
                        {
                            //do nothing
                        }
                        else
                        {
                            //Bow the personality and all their attachments
                            attPer.IsBowed = true;
                            foreach (Attachment att in attPer.getAllAttachedCards())
                            {
                                att.IsBowed = true;
                            }
                        }
                        //Send the unit home
                        attackingPlayer.cardsInPlay.Add(attPer);

                        //Also set a flag that the cards have been at the resolution of a battle as an attacking card(To stop them moving to other battlefields)
                    }
                }
                //Check if province is destroyed
                if (attTotal - defTotal > battlefieldProvince.currentProvinceStrength)
                {
                    battlefieldProvince.destroyProvince();
                }
            }

        }
    }
}

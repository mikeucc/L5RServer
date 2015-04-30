using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class TargetYourHonourablePersonality:ITarget
    {
        public override List<Card> returnTargetList(Gamestate gs, ICondition cond)
        {
            List<Card> returnList = new List<Card>();
            //Targeting a card at home
            if (gs.currentBattlefield == null)
            {
                foreach (Personality per in gs.performingPlayer.cardsInPlay)
                {
                    if (per.isHonourable == true)
                    {
                        if (cond.doesCardMeetCondition(per))
                        {
                            returnList.Add(per);
                        }
                    }
                }
            }
            // Targeting a card at battlefield
            else
            {   //Checks if the player cards are the attacking units and adds them to the return list 
                if (gs.performingPlayer.isAttacking == true)
                {
                    foreach (Personality per in gs.currentBattlefield.attackingUnits)
                    {
                        if (per.isHonourable == true)
                        {
                            if (cond.doesCardMeetCondition(per))
                            {
                                returnList.Add(per);
                            }
                        }
                    }
                }
                //Otherwise they are the defending units and adds them to the list
                else
                {
                    foreach (Personality per in gs.currentBattlefield.defendingUnits)
                    {
                        if (per.isHonourable == true)
                        {
                            returnList.Add(per);
                        }
                    }
                }

            }

            return returnList;
        }
    }
}

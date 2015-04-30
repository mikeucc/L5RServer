using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class TargetAPersonality:ITarget
    {
        public override List<Card> returnTargetList(Gamestate gs, ICondition cond)
        {
            List<Card> returnList = new List<Card>();
            //Targeting any personality(yours or opponents) card at home
            if (gs.currentBattlefield == null)
            {
                foreach (Personality per in gs.player1.cardsInPlay)
                {
                    if (cond.doesCardMeetCondition(per))
                    {
                        returnList.Add(per);
                    }
                }
                foreach (Personality per in gs.player2.cardsInPlay)
                {
                    if (cond.doesCardMeetCondition(per))
                    {
                        returnList.Add(per);
                    }
                }

            }
            // Targeting any personality(yours or opponents) at battlefield
            
            else
            {
                foreach (Personality per in gs.currentBattlefield.attackingUnits)
                {
                    if (cond.doesCardMeetCondition(per))
                    {
                        returnList.Add(per);
                    }
                }
                foreach (Personality per in gs.currentBattlefield.defendingUnits)
                {
                    if (cond.doesCardMeetCondition(per))
                    {
                        returnList.Add(per);
                    }
                }

            }

            return returnList;
        }

        
    }
}

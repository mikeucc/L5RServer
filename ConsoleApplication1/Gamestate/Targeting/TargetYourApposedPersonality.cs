using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class TargetYourApposedPersonality:ITarget
    {
        public override List<Card> returnTargetList(Gamestate gs, ICondition cond)
        {
            //List to be returned
            List<Card> returnList = new List<Card>();
            //if both counts are >0 we have an opposed battle
            if (gs.currentBattlefield.attackingUnits.Count > 0 && gs.currentBattlefield.defendingUnits.Count > 0)
            {
                foreach (Personality per in gs.currentBattlefield.myCards(gs.performingPlayer))
                {
                    if (cond.doesCardMeetCondition(per))
                    {
                        if (cond.doesCardMeetCondition(per))
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

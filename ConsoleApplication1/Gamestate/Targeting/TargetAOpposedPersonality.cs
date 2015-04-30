using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class TargetAOpposedPersonality
    {
        public List<Card> returnTargetList(Gamestate gs, Player performingPlayer, ICondition cond, Battlefield currentBattlefield)
        {
            //List to be returned
            List<Card> returnList = new List<Card>();
            //If both are >0 then we have an opposed battle
            if (currentBattlefield.attackingUnits.Count > 0 && currentBattlefield.defendingUnits.Count > 0)
            {
                foreach (Personality per in currentBattlefield.attackingUnits)
                {
                    if(cond.doesCardMeetCondition(per))
                    {
                        if (cond.doesCardMeetCondition(per))
                        {
                            returnList.Add(per);
                        }
                    }
                }
                foreach (Personality per in currentBattlefield.defendingUnits)
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

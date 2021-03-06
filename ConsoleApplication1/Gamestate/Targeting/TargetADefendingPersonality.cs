﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class TargetADefendingPersonality:ITarget
    {
        public TargetADefendingPersonality()
        {

        }

        public override List<Card> returnTargetList(Gamestate gs, ICondition cond)
        {
            List<Card> returnList = new List<Card>();
            foreach (Personality per in gs.currentBattlefield.defendingUnits)
            {
                if (cond.doesCardMeetCondition(per))
                {
                    returnList.Add(per);
                }
            }
            return returnList;
        }
    }
}

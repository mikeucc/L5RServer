﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class TargetYourDeadPersonality: ITarget
    {
        public override List<Card> returnTargetList(Gamestate gs, ICondition cond)
        {
            List<Card> returnList = new List<Card>();
            foreach (Personality per in gs.performingPlayer.pDynastyDiscard.getDisCardedPersonality(new ConditionStatusDead()))
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

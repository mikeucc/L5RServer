using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class ConditionPersonalityHasFollowerAttached:ICondition
    {
        public override bool doesCardMeetCondition(Card crd)
        {
            Personality per = (Personality)crd;
            bool returnValue = false;
            foreach (Follower fol in per.attachedCards)
            {
                returnValue = true;
            }

            return returnValue;
        }
    }
}

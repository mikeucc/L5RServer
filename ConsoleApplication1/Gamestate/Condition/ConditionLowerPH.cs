using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class ConditionLowerPH:ICondition
    {
        public override bool doesCardMeetCondition(Card crd)
        {
            Personality per = (Personality)crd;
            
            if (this.personalityOwner.personalHonor>per.personalHonor)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

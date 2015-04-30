using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class ConditionPersonalityStatusDishonoured:ICondition
    {
        public override bool doesCardMeetCondition(Card crd)
        {
            Personality per = (Personality)crd;
            
            
            if (per.isHonourable==false)
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

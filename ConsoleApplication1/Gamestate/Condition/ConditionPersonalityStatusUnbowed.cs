using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class ConditionPersonalityStatusUnbowed:ICondition
    {
        public override bool doesCardMeetCondition(Card crd)
        {
            if (crd.IsBowed == false)
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

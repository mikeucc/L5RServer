using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class ConditionStatusUnbowed:ICondition
    {
        public override bool doesCardMeetCondition(Card crd)
        {
            if (!crd.IsBowed)
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

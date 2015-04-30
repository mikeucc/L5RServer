using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class ConditionPersonalityStatusBowed:ICondition
    {
        public override bool doesCardMeetCondition(Card crd)
        {
            if (crd.IsBowed == true)
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

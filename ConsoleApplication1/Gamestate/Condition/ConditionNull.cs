using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class ConditionNull:ICondition
    {
        public override bool doesCardMeetCondition(Card crd)
        {
            return true;
        }
    }
}

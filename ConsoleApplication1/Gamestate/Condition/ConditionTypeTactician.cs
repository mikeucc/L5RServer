using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class ConditionTypeTactician:ICondition
    {
        public override bool doesCardMeetCondition(Card crd)
        {
            if (crd.traits.Contains(L5R.Gamestate.Gamestate.Tactician))
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

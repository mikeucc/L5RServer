using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class ConditionStatusCardFaceUp:ICondition
    {
        public override bool doesCardMeetCondition(Card crd)
        {
            if (!crd.IsFaceDown)
            {
                return true;
            }
            else
                return false;

        }
    }
}

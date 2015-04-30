using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class ConditionLowerForceThanDiscardedFocus:ICondition
    {
        public override bool doesCardMeetCondition(Card crd)
        {
            if (gs.performingPlayer.pFateDiscard.lastCardDiscarded().focusValue >= crd.currentForce)
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

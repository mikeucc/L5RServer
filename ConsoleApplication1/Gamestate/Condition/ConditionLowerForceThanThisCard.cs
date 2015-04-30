using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class ConditionLowerForceThanThisCard
    {
        Card conditionOwner { get; set; }

        public bool doesCardMeetCondition(Card crd)
        {
            if (conditionOwner.currentForce>crd.currentForce)
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

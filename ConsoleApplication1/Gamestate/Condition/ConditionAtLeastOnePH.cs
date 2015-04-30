using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class ConditionAtLeastOnePH:ICondition
    {
        public override bool doesCardMeetCondition(Card crd)
        {
            Personality tempCard = (Personality)crd;

            if (tempCard.personalHonor > 0)
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

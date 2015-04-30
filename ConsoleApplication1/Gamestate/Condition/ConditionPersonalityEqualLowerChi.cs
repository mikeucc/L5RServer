using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class ConditionPersonalityEqualLowerChi:ICondition
    {


        public override bool doesCardMeetCondition(Card crd)
        {
            Personality per = (Personality)crd;
            if (per.currentChi <= this.personalityOwner.currentChi)
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

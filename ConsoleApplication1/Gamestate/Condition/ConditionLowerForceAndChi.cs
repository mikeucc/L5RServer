using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class ConditionLowerForceAndChi:ICondition
    {
      

        public override bool doesCardMeetCondition(Card crd)
        {
            Personality per = (Personality)crd;

            if (per.currentChi < this.personalityOwner.currentChi && per.currentForce < this.personalityOwner.currentForce)
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

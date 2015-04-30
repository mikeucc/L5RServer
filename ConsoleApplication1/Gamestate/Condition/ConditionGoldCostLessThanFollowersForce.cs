using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class ConditionGoldCostLessThanFollowersForce :ICondition   
    {
        

        public override bool doesCardMeetCondition(Card crd)
        {
            Holding h = (Holding)crd;
            if (h.goldCost < this.followerOwner.currentForce)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5R.Gamestate
{
    public class ConditionLowerThanXForce:ICondition
    {
        public override bool doesCardMeetCondition(Card crd)
        {
            if(crd.currentForce<this.conditionOwner.effectValue)
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

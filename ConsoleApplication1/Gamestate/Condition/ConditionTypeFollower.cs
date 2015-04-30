using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5R.Gamestate
{
    public class ConditionTypeFollower:ICondition
    {
        public override bool doesCardMeetCondition(Card crd)
        {
            if(crd.GetType().Equals(typeof(Follower)))
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

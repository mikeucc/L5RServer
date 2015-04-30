using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class ConditionTypeRing:ICondition
    {
        public override bool doesCardMeetCondition(Card crd)
        {
            if (crd.traits.Contains(Gamestate.Ring))
            {
                return true;

            }
            else
            {
                return false;
            }

            
            //Just keeping the below as it is handy
            //Returns true if any items in the 2 lists match
            //per.traits.Intersect(traitRequirments).Any()
        }
    }
}

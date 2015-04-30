using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class ConditionTypeNonUnique:ICondition
    {
        public override bool doesCardMeetCondition(Card crd)
        {
            if (crd.traits.Contains(L5R.Gamestate.Gamestate.Unique))
            {
                return false;

            }
            else
            {
                return true;
            }


            //Just keeping the below as it is handy
            //Returns true if any items in the 2 lists match
            //per.traits.Intersect(traitRequirments).Any()
        }
    }
}

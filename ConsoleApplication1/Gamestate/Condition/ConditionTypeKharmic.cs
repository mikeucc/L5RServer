using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class ConditionTypeKharmic:ICondition
    {
        public override bool doesCardMeetCondition(Card crd)
        {
            //Will have to create static const strings for all keywords. Otherwises dreaded spelling mistakes will f things up
            if (crd.traits.Contains(Gamestate.Kharmic))
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

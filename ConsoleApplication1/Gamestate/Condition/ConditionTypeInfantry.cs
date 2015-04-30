using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class ConditionTypeInfantry:ICondition
    {
        public override bool doesCardMeetCondition(Card crd)
        {
            //Will have to create static const strings for all keywords. Otherwises dreaded spelling mistakes will f things up
            if (crd.traits.Contains(L5R.Gamestate.Gamestate.Infantry))
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

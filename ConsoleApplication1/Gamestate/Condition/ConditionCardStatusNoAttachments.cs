using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class ConditionCardStatusNoAttachments:ICondition
    {
        public override bool doesCardMeetCondition(Card crd)
        {

            if (crd.traits.Contains(L5R.Gamestate.Gamestate.Personality))
            {
                Personality p = (Personality)crd;
                if (p.attachedCards.Count < 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            //Only personalities can have attachments. So this will always be true
            else
            {
                return true;
            }
            
        }
    }
}

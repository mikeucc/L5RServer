using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class ConditionPersonalityHasAttachedWeapon
    {
        public bool doesCardMeetCondition(Card crd)
        {
            Personality per = (Personality)crd;
            bool returnValue=false;
            foreach (Weapon wp in per.attachedCards)
            {
                returnValue = true;
            }

            return returnValue;
        }
    }
}

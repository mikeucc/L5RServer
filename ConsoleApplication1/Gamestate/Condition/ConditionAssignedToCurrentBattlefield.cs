using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5R.Gamestate
{
    public class ConditionAssignedToCurrentBattlefield:ICondition
    {
        public override bool doesCardMeetCondition(Card crd)
        {
            Personality per = (Personality)crd;

            if(this.gs.currentBattlefield.Equals(per.assignedToThisBattfield))
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class TargetAAttackingPersonality:ITarget
    {
        
        
        public TargetAAttackingPersonality()
        {

        }

        public override List<Card> returnTargetList(Gamestate gs, ICondition cond)
        {
            List<Card> returnList = new List<Card>();
            foreach (Personality per in gs.currentBattlefield.attackingUnits)
            {
                if(cond.doesCardMeetCondition(per))
                {
                    returnList.Add(per);
                }
            }
            return returnList;
        }


    }
}

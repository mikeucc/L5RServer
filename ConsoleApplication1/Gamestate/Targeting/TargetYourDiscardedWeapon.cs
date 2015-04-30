using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class TargetYourDiscardedWeapon:ITarget
    {
        public override List<Card> returnTargetList(Gamestate gs, ICondition cond)
        {
            List<Card> returnList = new List<Card>();
            foreach (Weapon wep in gs.performingPlayer.pFateDiscard.getDiscardedWeapon())
            {
                if (cond.doesCardMeetCondition(wep))
                {
                    returnList.Add(wep);
                }

            }
            return returnList;
        }
    }
}

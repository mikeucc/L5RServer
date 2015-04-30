using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class TargetEnemyHolding:ITarget
    {
        public override List<Card> returnTargetList(Gamestate gs,ICondition cond)
        {
            List<Card> returnList = new List<Card>();

            foreach (Holding hol in gs.performingPlayer.opposingPlayer.cardsInPlay)
            {
                if (cond.doesCardMeetCondition(hol))
                {
                    returnList.Add(hol);
                }
            }

            return returnList;
        }
    }
}

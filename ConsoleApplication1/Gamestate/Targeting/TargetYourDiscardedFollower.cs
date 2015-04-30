using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate.Targeting
{
    class TargetYourDiscardedFollower
    {
        public List<Card> returnTargetList(Gamestate gs, Player performingPlayer, ICondition cond, Battlefield currentBattlefield)
        {
            List<Card> returnList = new List<Card>();
            foreach (Follower fol in performingPlayer.pFateDiscard.getDiscardedFollower())
            {
                if (cond.doesCardMeetCondition(fol))
                {
                    returnList.Add(fol);
                }

            }
            return returnList;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class TargetYourInHandFollower:ITarget
    {
        public override List<Card> returnTargetList(Gamestate gs, ICondition cond)
        {
            List<Card> returnList = new List<Card>();
            foreach (Follower fol in gs.performingPlayer.pHand.searchForFollower())
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class TargetYourInHandRing:ITarget
    {
        public override List<Card> returnTargetList(Gamestate gs, ICondition cond)
        {
            List<Card> returnList = new List<Card>();
            foreach (Ring rng in gs.performingPlayer.pHand.searchForRing())
            {
                if (cond.doesCardMeetCondition(rng))
                {
                    returnList.Add(rng);
                }

            }
            return returnList;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate.Targeting
{
    class TargetYourInHandStrategy
    {
        public List<Card> returnTargetList(Gamestate gs, Player performingPlayer, ICondition cond, Battlefield currentBattlefield)
        {
            List<Card> returnList = new List<Card>();
            foreach (Strategy str in performingPlayer.pHand.searchForStrategy())
            {
                if (cond.doesCardMeetCondition(str))
                {
                    returnList.Add(str);
                }

            }
            return returnList;
        }
    }
}

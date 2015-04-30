using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class TargetYourHolding:ITarget
    {
        List<Card> returnList = new List<Card>();
        public override List<Card> returnTargetList(Gamestate gs, ICondition cond)
        {

            foreach (Holding hld in gs.performingPlayer.cardsInPlay)
            {
                if (cond.doesCardMeetCondition(hld))
                {
                    returnList.Add(hld);
                }
            }

            return returnList;
        }
    }
}

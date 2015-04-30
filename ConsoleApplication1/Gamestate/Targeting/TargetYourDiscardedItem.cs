using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class TargetYourDiscardedItem:ITarget
    {
        public override List<Card> returnTargetList(Gamestate gs, ICondition cond)
        {
            List<Card> returnList = new List<Card>();
            foreach (Item itm in gs.performingPlayer.pFateDiscard.getDiscardedItem())
            {
                if(cond.doesCardMeetCondition(itm))
                {
                    returnList.Add(itm);
                }

            }
            return returnList;
        }
    }
}

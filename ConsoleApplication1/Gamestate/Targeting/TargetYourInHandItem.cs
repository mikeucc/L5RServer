using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class TargetYourInHandItem:ITarget
    {
        public override List<Card> returnTargetList(Gamestate gs, ICondition cond)
        {
            List<Card> returnList = new List<Card>();

            foreach(Item itm in gs.performingPlayer.pHand.searchForItem())
            {
                if (cond.doesCardMeetCondition(itm))
                {
                    returnList.Add(itm);
                }
            }

            
            return returnList;
        }
    }
}

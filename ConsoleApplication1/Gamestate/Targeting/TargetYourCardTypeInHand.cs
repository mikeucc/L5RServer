using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class TargetYourCardTypeInHand:ITarget
    {
        public override List<Card> returnTargetList(Gamestate gs, ICondition cond)
        {
            List<Card> returnList = new List<Card>();

            foreach (FateCard fCard in gs.performingPlayer.pHand.getCardsInHand())
            {
                if (cond.doesCardMeetCondition(fCard))
                {
                    returnList.Add(fCard);
                }
            }

            return returnList;
        }
    }
}

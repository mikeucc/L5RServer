using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class TargetYourAttachmentInFateDeck:ITarget
    {
        public override List<Card> returnTargetList(Gamestate gs, ICondition cond)
        {
            List<Card> returnList = new List<Card>();

            foreach (Attachment aCard in gs.performingPlayer.pHand.searchForAttachments())
            {
                if (cond.doesCardMeetCondition(aCard))
                {
                    returnList.Add(aCard);
                }
            }

            return returnList;
        }
    }
}

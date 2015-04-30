using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class TargetYourRing:ITarget
    {
        public override List<Card> returnTargetList(Gamestate gs, ICondition cond)
        {
            List<Card> returnList = new List<Card>();
            foreach (Ring crd in gs.performingPlayer.cardsInPlay)
            {
                //Personality is dishonoured
                if (cond.doesCardMeetCondition(crd))
                {
                    if (cond.doesCardMeetCondition(crd))
                    {
                        returnList.Add(crd);
                    }
                }

            }
            return returnList;
        }
    }
}

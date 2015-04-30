using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate.Targeting
{
    class TargetEnemyAttachment
    {
        public List<Card> returnTargetList(Gamestate gs, Player performingPlayer, ICondition cond, Battlefield currentBattlefield)
        {
            List<Card> returnList = new List<Card>();

            if (currentBattlefield == null)
            {
                foreach (Personality per in performingPlayer.opposingPlayer.cardsInPlay)
                {

                    foreach (Attachment att in per.attachedCards)
                    {
                        if (cond.doesCardMeetCondition(att))
                        {
                            returnList.Add(att);
                        }
                    }
                }

            }
            else
            {

                foreach (Personality per in currentBattlefield.opposingCards(performingPlayer))
                {
                    foreach (Attachment att in per.attachedCards)
                    {
                        if (cond.doesCardMeetCondition(att))
                        {
                            returnList.Add(att);
                        }
                    }
                }

            }

            return returnList;
        }
    }
}

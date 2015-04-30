using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class TargetEnemyPersonality:ITarget
    {
        public override List<Card> returnTargetList(Gamestate gs, ICondition cond)
        {
            List<Card> returnList = new List<Card>();

            if (gs.currentBattlefield == null)
            {
                foreach (Personality per in gs.performingPlayer.opposingPlayer.cardsInPlay)
                {
                    if (cond.doesCardMeetCondition(per))
                    {
                        returnList.Add(per);
                    }
                }

            }
            else
            {

                foreach (Personality per in gs.currentBattlefield.opposingCards(gs.performingPlayer))
                {
                    if (cond.doesCardMeetCondition(per))
                    {
                        returnList.Add(per);
                    }
                }

            }

            return returnList;
        }
    }
}

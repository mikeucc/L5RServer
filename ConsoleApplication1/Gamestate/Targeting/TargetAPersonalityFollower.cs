using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class TargetAPersonalityFollower:ITarget
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
                    foreach (Follower fol in per.getAllFollowers())
                    {
                        if (cond.doesCardMeetCondition(fol))
                        {
                            returnList.Add(fol);
                        }
                    }

                }
                foreach (Personality per in gs.performingPlayer.cardsInPlay)
                {
                    if (cond.doesCardMeetCondition(per))
                    {
                        returnList.Add(per);
                    }
                    foreach (Follower fol in per.getAllFollowers())
                    {
                        if (cond.doesCardMeetCondition(fol))
                        {
                            returnList.Add(fol);
                        }
                    }
                }

            }
            else
            {
                //Enemy cards
                foreach (Personality per in gs.currentBattlefield.opposingCards(gs.performingPlayer))
                {
                    if (cond.doesCardMeetCondition(per))
                    {
                        returnList.Add(per);
                    }
                    foreach (Follower fol in per.getAllFollowers())
                    {
                        if (cond.doesCardMeetCondition(fol))
                        {
                            returnList.Add(fol);
                        }
                    }

                }
                //my cards
                foreach (Personality per in gs.currentBattlefield.myCards(gs.performingPlayer))
                {
                    if (cond.doesCardMeetCondition(per))
                    {
                        returnList.Add(per);
                    }
                    foreach (Follower fol in per.getAllFollowers())
                    {
                        if (cond.doesCardMeetCondition(fol))
                        {
                            returnList.Add(fol);
                        }
                    }

                }

            }

            return returnList;
        }
    }
}

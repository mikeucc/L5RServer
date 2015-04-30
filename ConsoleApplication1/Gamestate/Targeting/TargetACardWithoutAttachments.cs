using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class TargetACardWithoutAttachments : ITarget
    {
        public override List<Card> returnTargetList(Gamestate gs,ICondition cond)
        {
            List<Card> returnList = new List<Card>();

            if (gs.currentBattlefield == null)
            {   //Enemy Cards
                foreach (Personality per in gs.performingPlayer.opposingPlayer.cardsInPlay)
                {
                    //Personality has no attachments
                    if (per.attachedCards.Count < 1)
                    {
                        if (cond.doesCardMeetCondition(per))
                        {
                            returnList.Add(per);
                        }
                    }
                    //Personality has attachments, Attachment do not have attached cards so return them instead
                    else
                    {

                        foreach (Attachment att in per.getAllAttachedCards())
                        {
                            if (cond.doesCardMeetCondition(att))
                            {
                                returnList.Add(att);
                            }
                        }

                    }
                }
                // Players cards
                foreach (Personality per in gs.performingPlayer.cardsInPlay)
                {
                    //Personality has no attachments
                    if (per.attachedCards.Count < 1)
                    {
                        if (cond.doesCardMeetCondition(per))
                        {
                            returnList.Add(per);
                        }
                    }
                    //Personality has attachments, Attachment do not have attached cards so return them instead
                    else
                    {

                        foreach (Attachment att in per.getAllAttachedCards())
                        {
                            if (cond.doesCardMeetCondition(att))
                            {
                                returnList.Add(att);
                            }
                        }

                    }
                }

            }
            else
            {
                //Enemy Cards
                foreach (Personality per in gs.currentBattlefield.opposingCards(gs.performingPlayer))
                {
                    //Personality has no attachments
                    if (per.attachedCards.Count < 1)
                    {
                        if (cond.doesCardMeetCondition(per))
                        {
                            returnList.Add(per);
                        }
                    }
                    //Personality has attachments, Attachment do not have attached cards so return them instead
                    else
                    {
                        foreach (Attachment att in per.getAllAttachedCards())
                        {
                            if (cond.doesCardMeetCondition(att))
                            {
                                returnList.Add(att);
                            }
                        }
                    }

                }
                //My Cards
                foreach (Personality per in gs.currentBattlefield.myCards(gs.performingPlayer))
                {
                    //Personality has no attachments
                    if (per.attachedCards.Count < 1)
                    {
                        if (cond.doesCardMeetCondition(per))
                        {
                            returnList.Add(per);
                        }
                    }
                    //Personality has attachments, Attachment do not have attached cards so return them instead
                    else
                    {
                        foreach (Attachment att in per.getAllAttachedCards())
                        {
                            if (cond.doesCardMeetCondition(att))
                            {
                                returnList.Add(att);
                            }
                        }
                    }

                }

            }

            return returnList;
        }
    }
}

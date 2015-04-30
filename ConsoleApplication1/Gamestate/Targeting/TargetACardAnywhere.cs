using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate.Targeting
{
    class TargetACardAnywhere
    {
        public List<Card> returnTargetList(Gamestate gs, Player performingPlayer, ICondition cond, Battlefield currentBattlefield)
        {
            List<Card> returnList = new List<Card>();
            if (currentBattlefield !=null)
            {
                //Enemy Cards
                foreach (Card crd in currentBattlefield.opposingCards(performingPlayer))
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
                //YourCards
                foreach (Card crd in currentBattlefield.myCards(performingPlayer))
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
            
                
                //Enemy Cards
                foreach (Card crd in performingPlayer.opposingPlayer.cardsInPlay)
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
                //Your cards
                foreach (Card crd in performingPlayer.cardsInPlay)
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


            }
            else
            {
                //Enemy Cards
                foreach (Card crd in performingPlayer.opposingPlayer.cardsInPlay)
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
                //Your cards
                foreach (Card crd in performingPlayer.cardsInPlay)
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


            }

            return returnList;
        }
    }
}

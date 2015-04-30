using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class TargetEnemyCard:ITarget
    {
        public override List<Card> returnTargetList(Gamestate gs, ICondition cond)
        {
            List<Card> returnList = new List<Card>();
            if (gs.currentBattlefield == null)
            {   //Enemy Cards
                foreach (Card crd in gs.performingPlayer.opposingPlayer.cardsInPlay)
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
                foreach (Card crd in gs.currentBattlefield.opposingCards(gs.performingPlayer))
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

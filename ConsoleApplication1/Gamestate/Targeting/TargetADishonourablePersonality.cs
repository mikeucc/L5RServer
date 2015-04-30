using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate.Targeting
{
    class TargetADishonourablePersonality:ITarget
    {
        public override List<Card> returnTargetList(Gamestate gs, ICondition cond)
        {
            List<Card> returnList = new List<Card>();
            if (gs.currentBattlefield == null)
            {   //Enemy Cards
                foreach (Personality per in gs.performingPlayer.opposingPlayer.cardsInPlay)
                {
                    //Personality is dishonoured
                    if (per.isHonourable==false)
                    {
                        if (cond.doesCardMeetCondition(per))
                        {
                            returnList.Add(per);
                        }
                    }
                    
                }
                // Players cards
                foreach (Personality per in gs.performingPlayer.cardsInPlay)
                {
                    //Personality is dishonoured
                    if (per.isHonourable == false)
                    {
                        if (cond.doesCardMeetCondition(per))
                        {
                            returnList.Add(per);
                        }
                    }
                }

            }
            else
            {
                //Enemy Cards
                foreach (Personality per in gs.currentBattlefield.opposingCards(gs.performingPlayer))
                {
                    //Personality is dishonoured
                    if (per.isHonourable == false)
                    {
                        if (cond.doesCardMeetCondition(per))
                        {
                            returnList.Add(per);
                        }
                    }

                }
                // Players cards
                foreach (Personality per in gs.currentBattlefield.myCards(gs.performingPlayer))
                {
                    //Personality is dishonoured
                    if (per.isHonourable == false)
                    {
                        if (cond.doesCardMeetCondition(per))
                        {
                            returnList.Add(per);
                        }
                    }
                }

            }

            return returnList;
        }

    }
}

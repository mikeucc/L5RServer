using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class TargetYourPersonality:ITarget
    {
        //This returns a list of cards(Will be personalities) either at home if not in the battle phase
        //Or at the current battle field (If currentBattlefield paramater is null it assume you want the cards at home

        public override List<Card> returnTargetList(Gamestate gs, ICondition cond)
        {
            List<Card> returnList=new List<Card>();
            //Targeting a card at home
            if (gs.currentBattlefield == null)
            {
                foreach (Personality per in gs.performingPlayer.cardsInPlay)
                {
                    if (cond.doesCardMeetCondition(per))
                    {
                        returnList.Add(per);
                    }
                }
            }
            // Targeting a card at battlefield
            else
            {
                foreach (Personality per in gs.currentBattlefield.myCards(gs.performingPlayer))
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

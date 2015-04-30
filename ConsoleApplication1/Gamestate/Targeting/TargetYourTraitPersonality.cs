using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class TargetYourTraitPersonality:ITarget
    {
        public override List<Card> returnTargetList(Gamestate gs, ICondition cond)
        {
            List<Card> returnList = new List<Card>();
            //Targeting a card at home
            if (gs.currentBattlefield == null)
            {
                foreach (Personality per in gs.performingPlayer.cardsInPlay)
                {
                    //If there is a trait match add to list
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class TargetYourUnbowedPersonality:ITarget
    {
        List<Card> returnList = new List<Card>();
        public override List<Card> returnTargetList(Gamestate gs, ICondition cond)
        {

            if (gs.currentBattlefield == null)
            {
                foreach (Personality per in gs.performingPlayer.cardsInPlay)
                {
                    if (per.IsBowed == false)
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
                foreach (Personality per in gs.currentBattlefield.myCards(gs.performingPlayer))
                {
                    if (per.IsBowed == false)
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

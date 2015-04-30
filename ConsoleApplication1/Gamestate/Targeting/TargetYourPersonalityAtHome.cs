using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate.Targeting
{
    class TargetYourPersonalityAtHome
    {
        public List<Card> returnTargetList(Gamestate gs, Player performingPlayer, ICondition cond, Battlefield currentBattlefield)
        {
            List<Card> returnList = new List<Card>();
            //Targeting a card at home
            if (currentBattlefield == null)
            {
                foreach (Personality per in performingPlayer.cardsInPlay)
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

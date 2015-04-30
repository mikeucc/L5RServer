using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate.Targeting
{
    class TargetYourCardInProvince
    {
        public List<Card> returnTargetList(Gamestate gs, Player performingPlayer, ICondition cond, Battlefield currentBattlefield)
        {
            List<Card> returnList = new List<Card>();

            foreach(Province prov in performingPlayer.playerProvinces)
            {

                if (cond.doesCardMeetCondition(prov.purchasableCard))
                {
                    returnList.Add(prov.purchasableCard);
                }
            }

            return returnList;
        }
    }
}

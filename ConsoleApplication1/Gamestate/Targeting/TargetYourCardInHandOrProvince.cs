using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class TargetYourCardInHandOrProvince:ITarget
    {
        public override List<Card> returnTargetList(Gamestate gs, ICondition cond)
        {
            List<Card> returnList = new List<Card>();

            foreach(FateCard crd in gs.performingPlayer.pHand.getCardsInHand())
            {
                if (cond.doesCardMeetCondition(crd))
                {
                    returnList.Add(crd);
                }
            }

            foreach (Province pv in gs.performingPlayer.playerProvinces)
            {
                if (cond.doesCardMeetCondition(pv.purchasableCard))
                {
                    returnList.Add(pv.purchasableCard);
                }
            }

            return returnList;
        }
    }
}

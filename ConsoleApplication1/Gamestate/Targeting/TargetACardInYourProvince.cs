using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class TargetACardInYourProvince:ITarget
    {

        public List<Card> returnList = new List<Card>();
        public override List<Card> returnTargetList(Gamestate gs, ICondition cond)
        {
            foreach (Province prov in gs.performingPlayer.playerProvinces)
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

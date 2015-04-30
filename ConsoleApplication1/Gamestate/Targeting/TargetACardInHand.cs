using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class TargetACardInHand:ITarget
    {
        public List<Card> returnList=new List<Card>();

        
        public override List<Card> returnTargetList(Gamestate gs, ICondition cond)
        {
            foreach (Card crd in gs.performingPlayer.pHand.getCardsInHand())
            {
                returnList.Add(crd);
            }

            return returnList;
        }
    }
}

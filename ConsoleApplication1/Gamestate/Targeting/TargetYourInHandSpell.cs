using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class TargetYourInHandSpell:ITarget
    {
        public override List<Card> returnTargetList(Gamestate gs, ICondition cond)
        {
            List<Card> returnList = new List<Card>();
            foreach (Spell spl in gs.performingPlayer.pHand.searchForSpell())
            {
                if (cond.doesCardMeetCondition(spl))
                {
                    returnList.Add(spl);
                }

            }
            return returnList;
        }

    }
}

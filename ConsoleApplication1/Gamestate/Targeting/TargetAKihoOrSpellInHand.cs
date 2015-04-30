using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class TargetAKihoOrSpellInHand:ITarget
    {
        public List<Card> returnList = new List<Card>();


        public override List<Card> returnTargetList(Gamestate gs, ICondition cond)
        {
            foreach (Spell crd in gs.performingPlayer.pHand.searchForSpell())
            {
                returnList.Add(crd);
            }

            foreach (Kiho crd in gs.performingPlayer.pHand.searchForKiho())
            {
                returnList.Add(crd);
            }

            return returnList;
        }
    }
}

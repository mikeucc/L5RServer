using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class TargetYourDefendingPersonalities:ITarget
    {
        public override List<Card> returnTargetList(Gamestate gs, ICondition cond)
        {
            List<Card> returnList = new List<Card>();

            foreach (Personality per in gs.currentBattlefield.defendingUnits)
            {
                //just checking that you actually own the defending personality
                if (per.playerOwner.Equals(gs.performingPlayer))
                {
                    returnList.Add(per);
                }
            }
            return returnList;
        }
    }
}

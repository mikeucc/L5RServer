using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class TargetEnemyFollowerOrPersonalityWithoutFollower:ITarget
    {
        public override List<Card> returnTargetList(Gamestate gs, ICondition cond)
        {
            List<Card> returnList = new List<Card>();
            foreach (Personality per in gs.currentBattlefield.opposingCards(gs.performingPlayer))
            {
                if (per.getAllFollowers().Count == 0)
                {
                    returnList.Add(per);
                }
                else
                {
                    foreach (Follower fol in per.getAllFollowers())
                    {
                        returnList.Add(fol);
                    }
                }
            }

            return returnList;
        }
    }
}

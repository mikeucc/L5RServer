using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class TargetUnbowedFollowerOnYourPersonality:ITarget
    {
        public override List<Card> returnTargetList(Gamestate gs, ICondition cond)
        {
            List<Card> returnList = new List<Card>();
            Personality actionPer=(Personality)gs.currentActionBeingPlayedCard;

            foreach (Follower fol in actionPer.attachedCards)
            {
                if (!fol.IsBowed)
                {
                    returnList.Add(fol);
                }

            }

            return returnList;
        }
    }
}

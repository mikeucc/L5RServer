using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class ERecruitCostModificationFollower:IEffect
    {
        public override bool applyEffects(Gamestate gs)
        {
            this.effectOwner.modifyGoldCostFollower += this.conditionalModifierValue;
            return true;
        }
    }
}

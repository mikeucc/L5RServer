using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class ETactician:IEffect
    {
        public override bool applyEffects(Gamestate gs)
        {
            FateCard chosenCard=(FateCard)gs.pickTarget(new TargetACardInHand().returnTargetList(gs,new ConditionNull()),gs.performingPlayer);
            this.cardOwner.tempforceModifier += chosenCard.focusValue;
            gs.performingPlayer = gs.getOpposingPlayer(gs.performingPlayer);
            return true;

        } 
    }
}

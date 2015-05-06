using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class EPayGold:IEffect
    {
        public override bool applyEffects(Gamestate gs)
        {
            this.playerEffected.payGoldCost(this.effectValue);
            gs.performingPlayer = gs.getOpposingPlayer(gs.performingPlayer);
            return true;
        }
    }
}

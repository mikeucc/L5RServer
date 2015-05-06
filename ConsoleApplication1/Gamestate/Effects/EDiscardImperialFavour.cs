using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class EDiscardImperialFavour:IEffect
    {
        public override bool applyEffects(Gamestate gs)
        {
            if (this.cardOwner.playerOwner.hasImperialFavour)
            {
                this.cardOwner.playerOwner.hasImperialFavour = false;
                gs.performingPlayer = gs.getOpposingPlayer(gs.performingPlayer);
                return true;
            }
            else
            {
                gs.performingPlayer = gs.getOpposingPlayer(gs.performingPlayer);
                return false;
            }
        }
    }
}

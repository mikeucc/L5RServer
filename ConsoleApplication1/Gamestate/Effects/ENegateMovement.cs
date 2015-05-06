using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class ENegateMovement:IEffect
    {
        public override bool applyEffects(Gamestate gs)
        {
            gs.currentActionBeingPlayed.willMove = false;
            gs.performingPlayer = gs.getOpposingPlayer(gs.performingPlayer);
            return true;
        }
    }
}

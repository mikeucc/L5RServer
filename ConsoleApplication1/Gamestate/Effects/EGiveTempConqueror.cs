using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class EGiveTempConqueror:IEffect
    {
        public override bool applyEffects(Gamestate gs)
        {
            foreach (Card crd in gs.pickTargets(this.effectTarget.returnTargetList(gs, this.effectCondition), this.effectTarget.numOfTargets, gs.performingPlayer))
            {
                crd.tempTraits.Add(Gamestate.Conqueror);
            }
            gs.performingPlayer = gs.getOpposingPlayer(gs.performingPlayer);
            return true;
        }
    }
}

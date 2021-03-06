﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class EForceModifier:IEffect
    {
        public override bool applyEffects(Gamestate gs)
        {


            foreach (Card crd in gs.pickTargets(this.effectTarget.returnTargetList(gs, this.effectCondition), this.effectTarget.numOfTargets, gs.performingPlayer))
            {
                crd.tempforceModifier += this.effectValue;
            }
            gs.performingPlayer = gs.getOpposingPlayer(gs.performingPlayer);
            return true;
        }
    }
}

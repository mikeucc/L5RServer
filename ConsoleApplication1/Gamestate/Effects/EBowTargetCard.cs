using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class EBowTargetCard:IEffect
    {
        public override bool applyEffects(Gamestate gs)
        {
            bool returnValue = true;

            foreach (Card crd in gs.pickTargets(this.effectTarget.returnTargetList(gs, this.effectCondition), this.effectTarget.numOfTargets, gs.performingPlayer)) 
            {
                if (crd.IsBowed == true)
                {
                    returnValue = false;
                }
                
                crd.IsBowed = true;
                
            }
            gs.performingPlayer = gs.getOpposingPlayer(gs.performingPlayer);
            return returnValue;
        }
    }
}

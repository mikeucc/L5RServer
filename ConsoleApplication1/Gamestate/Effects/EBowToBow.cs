using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class EBowToBow:IEffect
    {
        public override bool applyEffects(Gamestate gs)
        {
            bool returnValue = true;

            foreach (Card crd in gs.pickTargets(this.effectTarget.returnTargetList(gs, this.effectCondition), this.effectTarget.numOfTargets, gs.performingPlayer))
            {
                if (this.effectOwner.actionOwner.IsBowed == false)
                {
                    crd.IsBowed = true;
                    this.effectOwner.actionOwner.IsBowed = true;
                }
                else
                {
                    returnValue = false;
                }
            }

            return returnValue;
        } 
    }
}

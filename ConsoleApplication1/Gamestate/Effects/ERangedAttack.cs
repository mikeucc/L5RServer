using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class ERangedAttack:IEffect
    {
        
        public override bool applyEffects(Gamestate gs)
        {
            bool returnValue = true;
            foreach (Card crd in gs.pickTargets(this.effectTarget.returnTargetList(gs, this.effectCondition), this.effectTarget.numOfTargets, gs.performingPlayer))
            {
                if (crd.currentForce<= this.effectValue+this.effectOwner.modifyRanged)
                {
                    if (this.effectOwner.willDestroy == true)
                    { 
                        crd.destroyCard(); 
                    }
                    else
                    {
                        returnValue = false;
                    }
                }
            }

            return returnValue;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5R.Gamestate
{
    public class EValueOfTargetedCardsForce:IEffect
    {
        public override bool applyEffects(Gamestate gs)
        {
            if (this.effectOwner.targetsSelected)
            {
                this.effectOwner.targetsSelected = false;
                foreach(Card crd in this.effectOwner.selectedTargets)
                {
                    this.effectValue += crd.currentForce;
                    
                }

                this.effectOwner.previousEffectValue = this.effectValue;

                return true;
            }
            else
            {
                this.effectOwner.selectedTargets.AddRange(gs.pickTargets(this.effectTarget.returnTargetList(gs, this.effectCondition), this.effectTarget.numOfTargets, this.effectOwner.actionOwner.playerOwner));
                this.effectOwner.targetsSelected = true;
                this.applyEffects(gs);
            }

            return false;
        }
    }
}

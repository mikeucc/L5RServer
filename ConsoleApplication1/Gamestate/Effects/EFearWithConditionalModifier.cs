using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class EFearWithConditionalModifier:IEffect
    {
        public override bool applyEffects(Gamestate gs)
        {
            foreach (Card crd in gs.pickTargets(this.effectTarget.returnTargetList(gs, this.effectCondition), this.effectTarget.numOfTargets, gs.performingPlayer))
            {
                if (effectCondition.doesCardMeetCondition(crd))
                {
                    if (crd.currentForce <= this.effectValue+this.conditionalModifierValue)
                    {
                        crd.IsBowed = true;
                    }
                }
                else
                {
                    if (crd.currentForce <= this.effectValue)
                    {
                        crd.IsBowed = true;
                    }
                }
                
                
            }

            return true;
        }
    }
}

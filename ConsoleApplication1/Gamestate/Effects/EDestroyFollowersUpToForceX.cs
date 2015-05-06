using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5R.Gamestate
{
    public class EDestroyFollowersUpToForceX:IEffect
    {
        public override bool applyEffects(Gamestate gs)
        {
            if(valueSetByPrevious)
            {
                // only set the first time, otherwise the recursion would never end
                this.effectValue=this.effectOwner.previousEffectValue;
                valueSetByPrevious = false;
            }
            
            
            if (this.effectOwner.targetsSelected)
            {
                foreach(Card crd in this.effectOwner.selectedTargets)
                {
                    crd.destroyCard();
                }
                gs.performingPlayer = gs.getOpposingPlayer(gs.performingPlayer);
                return true;
            }
            else
            {

                this.effectOwner.selectedTargets.Clear();

                this.effectOwner.selectedTargets.Add(gs.pickTarget(this.effectTarget.returnTargetList(gs, this.effectCondition),this.effectOwner.actionOwner.playerOwner));
                this.effectValue-=this.effectOwner.selectedTargets.Last().currentForce;

                //There was no valid targets left, so it jumps to executing the effect
                if(this.effectOwner.selectedTargets.Count==0)
                {
                    this.effectOwner.targetsSelected = true;
                    this.applyEffects(gs);
                }
                
                
            }
            gs.performingPlayer = gs.getOpposingPlayer(gs.performingPlayer);
            return false;
        }
    }
}

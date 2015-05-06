using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5R.Gamestate
{
    public class ENull:IEffect
    {
        public override bool applyEffects(Gamestate gs)
        {
            if(this.effectOwner.targetsSelected)
            {
                this.effectOwner.targetsSelected = false;
                gs.performingPlayer = gs.getOpposingPlayer(gs.performingPlayer);
                return true;
            }
            else
            {
                this.effectOwner.selectedTargets.AddRange(gs.pickTargets(this.effectTarget.returnTargetList(gs, this.effectCondition), this.effectTarget.numOfTargets, this.effectOwner.actionOwner.playerOwner));
                this.effectOwner.targetsSelected = true;
                this.applyEffects(gs);
            }
            gs.performingPlayer = gs.getOpposingPlayer(gs.performingPlayer);
            return false;
        }
    }
}

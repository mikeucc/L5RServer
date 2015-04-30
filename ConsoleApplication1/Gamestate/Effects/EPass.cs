using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class EPass:IEffect
    {
        public override bool applyEffects(Gamestate gs)
        {
            if (this.effectOwner is ActionInterrupt||this.effectOwner is ActionRecruitInterrupt)
            {
                gs.performingPlayer.InterruptHasPassed = true;
                this.effectOwner.actionOwner.playerOwner.InterruptHasPassed = true;
                Console.WriteLine(gs.performingPlayer.aLabel+" Interrupt pass");
                

            }
            else
            {
                gs.performingPlayer.InterruptHasPassed = true;
                this.effectOwner.actionOwner.playerOwner.hasPassed = true;
                Console.WriteLine(gs.performingPlayer.aLabel+" Action Pass");
                
            }

            return true;
        }
    }
}

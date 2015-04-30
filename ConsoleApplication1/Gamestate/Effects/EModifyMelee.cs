using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class EModifyMelee: IEffect
    {
        public override bool applyEffects(Gamestate gs)
        {
            gs.currentActionBeingPlayed.modifyMelee += this.effectValue;
            return true;
        }

        
    }
}

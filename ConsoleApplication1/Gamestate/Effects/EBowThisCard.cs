using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class EBowThisCard:IEffect
    {
        public override bool applyEffects(Gamestate gs)
        {
            bool returnValue = true;
            if (this.effectOwner.actionOwner.IsBowed == true)
            {
                returnValue = false;
            }
            
            this.effectOwner.actionOwner.IsBowed = true;
            gs.performingPlayer = gs.getOpposingPlayer(gs.performingPlayer);
            return returnValue;
        }
    }
}

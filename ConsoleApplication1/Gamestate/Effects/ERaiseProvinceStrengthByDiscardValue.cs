using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class ERaiseProvinceStrengthByDiscardValue:IEffect
    {
        public override bool applyEffects(Gamestate gs)
        {
            gs.currentBattlefield.battlefieldProvince.currentProvinceStrength += this.effectOwner.focusValueDiscard;
            gs.performingPlayer = gs.getOpposingPlayer(gs.performingPlayer);
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class ERaiseProvinceStrengthByValue:IEffect
    {
        public override bool applyEffects(Gamestate gs)
        {
            gs.currentBattlefield.battlefieldProvince.currentProvinceStrength += this.effectValue;
            return true;
        }
    }
}

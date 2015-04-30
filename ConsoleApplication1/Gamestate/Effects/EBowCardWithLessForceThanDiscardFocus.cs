using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class EBowCardWithLessForceThanDiscardFocus:IEffect
    {
        public override bool applyEffects(Gamestate gs)
        {

            int focusValue = this.effectOwner.focusValueDiscard;
            Card selectedCard = gs.pickTarget(this.effectTarget.returnTargetList(gs, this.effectCondition), gs.performingPlayer);

            if (selectedCard.currentForce < focusValue)
            {
                selectedCard.IsBowed = true;
            }
            return true;
        }
    }
}

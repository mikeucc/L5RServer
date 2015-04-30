using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class EDestroyActionsCard:IEffect
    {
        public override bool applyEffects(Gamestate gs)
        {

            if (effectOwner.willDestroy == true)
            {
                effectOwner.actionOwner.destroyCard();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

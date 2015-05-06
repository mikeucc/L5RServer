using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public abstract class IEffect
    {
        public IEffect()
        {

        }

        public int effectValue { get; set; }

        public int conditionalModifierValue { get; set; }

        public ITarget effectTarget { get; set; }

        public ICondition effectCondition { get; set; }

        public IAction effectOwner;

        public Card cardOwner;

        public Player playerEffected;

        public bool valueSetByPrevious;

        public virtual bool applyEffects(Gamestate gs)
        {
            gs.performingPlayer = gs.getOpposingPlayer(gs.performingPlayer);
            return true;
        }

        public virtual bool canBePlayed(Gamestate gs)
        {
            return true;
        }

        public bool requiredToContinue;

    }
}

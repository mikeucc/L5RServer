using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class IVE_091:Personality
    {
        public override void createCard(Player owner)
        {
            this.name = "";
            this.printedChi = 3;
            this.printedForce = 3;
            this.honorRequirement = -40;
            this.goldCost = 5;
            this.personalHonor = 2;
            this.canProduceGold = false;
            this.playerOwner = owner;
           

            ActionBattle ab = new ActionBattle();

            ab.actionOwner = this;
            ab.displayActionText="Earth Battle: Discard a Kiho or a Spell from your hand to give this Province a strength bonus equal to the card's Focus Value.";
            ab.gs = playerOwner.gs;

            EDiscardACardForFocusValue edf = new EDiscardACardForFocusValue();
            edf.effectOwner = ab;
            edf.cardOwner = this;
            edf.effectTarget = new TargetAKihoOrSpellInHand();
            edf.effectCondition = new ConditionNull();

            ab.actionsEffects.Add(edf);
            ab.actionsEffects.Add(new ERaiseProvinceStrengthByDiscardValue());
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class IVE_085: Personality
    {
        public override void createCard(Player owner)
        {
            this.printedForce = 3;
            this.printedChi = 3;
            this.honorRequirement = 3;
            this.goldCost = 5;
            this.personalHonor = 2;
            this.canProduceGold = false;

            this.traits.Add(Gamestate.DragonClan);
            this.traits.Add(Gamestate.Samurai);
            this.traits.Add(Gamestate.Duelist);
            this.name = "Mirumoto Hikuryo";

            this.cardAbilities.Add(new ActionBattle());
            EFearWithConditionalModifier effect = new EFearWithConditionalModifier();
            effect.effectValue = 2;
            effect.conditionalModifierValue = 1;
            effect.effectTarget = new TargetEnemyFollowerOrPersonalityWithoutFollower();
            effect.effectCondition = new ConditionPersonalityStatusDishonoured();

            this.cardAbilities[0].actionsEffects.Add(effect);
            this.playerOwner = owner;
        }
    }
}

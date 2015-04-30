using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class IVE_073:Personality
    {
        public override void createCard(Player owner)
        {
            this.name = "Daidoji Tametaka";
            this.printedForce = 4;
            this.printedChi = 4;
            this.honorRequirement = 4;
            this.goldCost = 8;
            this.personalHonor = 2;
            this.canProduceGold = false;

            this.traits.Add(Gamestate.CraneClan);
            this.traits.Add(Gamestate.Samurai);
            this.traits.Add(Gamestate.Scout);
            this.traits.Add(Gamestate.Commander);

            this.cardAbilities.Add(new ActionBattle());

            this.cardAbilities[0].actionsEffects.Add(new EForceModifier());
            this.cardAbilities[0].actionsEffects[0].effectValue = -4;
            this.cardAbilities[0].actionsEffects[0].effectTarget = new TargetEnemyPersonalityFollower();
            this.cardAbilities[0].actionsEffects[0].effectCondition = new ConditionNull();

            this.cardAbilities[0].actionsEffects.Add(new ESendUnitHome());
            this.cardAbilities[0].actionsEffects[1].effectTarget = new TargetYourPersonality();
            this.cardAbilities[0].actionsEffects[1].effectCondition = new ConditionNull();

            this.playerOwner = owner;

        }
    }
}

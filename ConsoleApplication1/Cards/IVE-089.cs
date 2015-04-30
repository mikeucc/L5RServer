using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class IVE_089:Personality
    {
        public override void createCard(Player owner)
        {
            this.name = "Mirumoto Tsukazu";
            this.printedChi = 3;
            this.printedForce = 3;
            this.personalHonor = 2;
            this.honorRequirement = 3;
            this.goldCost = 5;
            this.canProduceGold = false;
            this.traits.Add(Gamestate.DragonClan);
            this.traits.Add(Gamestate.Samurai);
            this.traits.Add(Gamestate.Kensai);

            this.cardAbilities.Add(new ActionBattle());

            EBowTargetCard effect = new EBowTargetCard();
            effect.effectTarget = new TargetEnemyPersonality();
            effect.effectCondition = new ConditionLowerForceAndChi();
            effect.effectCondition.personalityOwner = this;

            this.cardAbilities[0].actionsEffects.Add(effect);

            this.playerOwner = owner;
        }
    }
}

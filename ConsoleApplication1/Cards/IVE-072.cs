using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class IVE_072:Personality
    {
        public override void createCard(Player owner)
        {
            this.name = "Daidoji Kinta";
            this.printedChi = 2;
            this.printedForce = 2;
            this.honorRequirement = 6;
            this.goldCost = 6;
            this.personalHonor = 3;
            this.canProduceGold = false;

            this.traits.Add(Gamestate.CraneClan);
            this.traits.Add(Gamestate.Samurai);
            this.playerOwner = owner;

            ActionBattle tempAction = new ActionBattle();
            tempAction.displayActionText = "Bow: Ranged 4 Attack (Destroy a target enemy Follower, or Personality without Followers, with 4 or lower Force).";
            tempAction.actionOwner = this;

            ERangedAttack tempEffect = new ERangedAttack();
            tempEffect.effectOwner = tempAction;
            tempEffect.effectValue = 4;
            tempEffect.effectCondition = new ConditionNull();
            tempEffect.effectTarget = new TargetEnemyFollowerOrPersonalityWithoutFollower();

            tempAction.actionsEffects.Add(tempEffect);

            this.cardAbilities.Add(tempAction);

        }
    }
}

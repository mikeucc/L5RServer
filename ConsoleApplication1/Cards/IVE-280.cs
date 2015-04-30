using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5R.Gamestate
{
    public class IVE_280:Strategy
    {
        public override void createCard(Player owner)
        {
            this.playerOwner = owner;
            this.name = "A Champions Strike";
            this.focusValue = 3;

            ActionBattle ab = new ActionBattle();
            ab.displayActionText = "Battle: Target your unbowed Unique Samurai. Destroy one or more target enemy Followers with a total Force less than or equal to your Samurai's.";

            EValueOfTargetedCardsForce ef = new EValueOfTargetedCardsForce();
            ef.effectTarget = new TargetAPersonality();
            //Need new condition for this effect Unique and Samuari
            ef.effectCondition = new ConditionTypeUnique();
            ef.effectOwner = ab;
            ef.cardOwner = this;

            EDestroyFollowersUpToForceX ef2=new EDestroyFollowersUpToForceX();
            ef2.effectTarget = new TargetEnemyCard();
            ef2.effectCondition = new ConditionTypeFollower();
            ef.cardOwner = this;
            ef.effectOwner = ab;

            ab.actionsEffects.Add(ef);
            ab.actionsEffects.Add(ef2);


        }
    }
}

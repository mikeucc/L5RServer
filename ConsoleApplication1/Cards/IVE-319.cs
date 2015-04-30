using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class IVE_319:Strategy
    {
        public override void createCard(Player owner)
        {
            this.playerOwner = owner;
            this.name = "Incapacitated";
            this.focusValue = 2;
            this.canProduceGold = false;

            this.cardAbilities.Add(new ActionBattle());
            this.cardAbilities[0].actionsEffects.Add(new ESendUnitHome());
            this.cardAbilities[0].actionsEffects[0].effectTarget = new TargetADefendingPersonality();
            this.cardAbilities[0].actionsEffects[0].effectCondition = new ConditionNull();
            this.cardAbilities[0].displayActionText = "Battle: Move home a target defending Personality.";
            this.cardAbilities[0].actionOwner = this;
            this.cardAbilities[0].gs = owner.gs;
        }
    }
}

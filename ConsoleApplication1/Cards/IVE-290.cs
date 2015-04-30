using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5R.Gamestate
{
    public class IVE_290:Strategy
    {
        public override void createCard(Player owner)
        {
            this.playerOwner = owner;
            this.name = "Back to the Front";
            this.focusValue = 3;

            ActionAbsentBattle ab = new ActionAbsentBattle();
            ab.actionOwner = this;
            ab.displayActionText = "Absent Battle: Target your Personality at any location who assigned to this battlefield (this turn). Move him there and straighten his unit as he moves. (You may take Absent actions without presence.)";

            EMoveToCurrentBattledield ef = new EMoveToCurrentBattledield();
            ef.effectTarget = new TargetAPersonality();
            ef.effectCondition = new ConditionAssignedToCurrentBattlefield();
            ef.effectOwner = ab;
            EStraightenUnit ef2 = new EStraightenUnit();
            ef2.effectTarget = new TargetAPersonality();
            ef2.effectCondition = new ConditionAssignedToCurrentBattlefield();
            ef2.effectOwner = ab;

            ab.actionsEffects.Add(ef2);
            ab.actionsEffects.Add(ef);

            this.cardAbilities.Add(ab);
            
        }
    }
}

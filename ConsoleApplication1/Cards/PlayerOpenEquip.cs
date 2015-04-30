using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class PlayerOpenEquip:PlayerCard
    {
        public override bool canBeRecruitedBy(Player p)
        {
            throw new NotImplementedException();
        }

        public override void getDiscardedBy(Player p)
        {
            throw new NotImplementedException();
        }

        public override void createCard(Player owner)
        {
            this.playerOwner = owner;
            this.name = "Equip";
            ActionOpenRepeatable tempAction = new ActionOpenRepeatable();
            tempAction.displayActionText = "Repeatable Open,*: Attach an attachment card, with Gold Cost equal to the amount you paid, from your hand to your target Personality.";

            tempAction.gs = playerOwner.gs;
            tempAction.actionOwner = this;

            ERecruitAttachment ra = new ERecruitAttachment();
            ra.effectCondition = new ConditionTypeAttachment();
            ra.effectTarget = new TargetACardInHand();

            ra.cardOwner = this;
            ra.effectOwner = tempAction;


            tempAction.actionsEffects.Add(ra);
            this.cardAbilities.Add(tempAction);
        }
    }
}

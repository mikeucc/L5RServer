using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class PlayerDynastyRefill:PlayerCard
    {
        public override bool canBeRecruitedBy(Player p)
        {
            return base.canBeRecruitedBy(p);
        }

        public override void getDiscardedBy(Player p)
        {
            base.getDiscardedBy(p);
        }

        public override void createCard(Player owner)
        {
            this.playerOwner = owner;

            ActionDynastyRepeatable adr = new ActionDynastyRepeatable();
            adr.actionOwner = this;
            adr.gs = this.playerOwner.gs;
            adr.displayActionText = "Repeatable Dynasty: Discard a face-up card from one of your Provinces. (Rell it face-down.)";

            ERefillProvince erp = new ERefillProvince();
            erp.cardOwner = this;
            erp.effectOwner = adr;

            erp.effectCondition = new ConditionNull();

            adr.actionsEffects.Add(erp);

            this.cardAbilities.Add(adr);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class PlayerLimitedRepeatableKharmic:PlayerCard
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
            this.name = "Kharmic";

            ActionLimitedReapatable alr = new ActionLimitedReapatable();
            alr.actionOwner = this;
            alr.displayActionText = "Kharmic Repeatable Limited,2:Discard a Kharmic card from your hand to draw a card, or discard a Kharmic card from your Province to rell the Province face-up.";

            EKharmic ek = new EKharmic();

            ek.cardOwner = this;
            ek.effectOwner = alr;

            alr.actionsEffects.Add(ek);

        }
    }
}

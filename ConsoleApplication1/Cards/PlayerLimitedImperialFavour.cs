using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class PlayerLimitedImperialFavour:PlayerCard
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
            this.name = "Limited Imperial Favour";

            ActionLimitedPolitical pl = new ActionLimitedPolitical();
            pl.actionOwner = this;
            pl.displayActionText = "Favor Political Limited: Discard the Imperial Favor and a card to draw a card.";
            pl.gs = playerOwner.gs;

            EDiscardImperialFavour df=new EDiscardImperialFavour();
            df.requiredToContinue=true;
            df.effectOwner=pl;
            df.cardOwner=this;
            pl.actionsEffects.Add(df);

            EDiscardACard dc = new EDiscardACard();
            dc.requiredToContinue = true;
            dc.effectOwner = pl;
            dc.cardOwner = this;
            dc.effectTarget = new TargetACardInHand();
            dc.effectTarget.numOfTargets = 1;
            pl.actionsEffects.Add(dc);

            EDrawACard draw = new EDrawACard();
            draw.requiredToContinue = false;
            draw.effectOwner = pl;
            draw.cardOwner = this;
            pl.actionsEffects.Add(draw);

            this.cardAbilities.Add(pl);

        }
    }
}

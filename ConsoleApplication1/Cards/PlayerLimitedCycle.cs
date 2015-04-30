using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class PlayerLimitedCycle:PlayerCard
    {
        public override void createCard(Player owner)
        {
            this.playerOwner = owner;
            this.name = "Player Limited Cycle";
            
            ActionLimited al = new ActionLimited();
            al.actionOwner = this;
            al.displayActionText = "Limited: If it is your firrst turn, choose one or more face-up cards in your Provinces. Put them on the bottom of your deck in any order.(Rell the empty Provinces face-down.) Then,turn all cards in your Provinces face-up.";
            al.gs = playerOwner.gs;
            ECycle ec = new ECycle();
            ec.effectCondition = new ConditionStatusCardFaceUp();
            ec.effectTarget = new TargetACardInYourProvince();
            ec.effectOwner = al;
            ec.cardOwner = this;

            al.actionsEffects.Add(ec);
            this.cardAbilities.Add(al);
        }

        public override bool canBeRecruitedBy(Player p)
        {
            throw new NotImplementedException();
        }

        public override void getDiscardedBy(Player p)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class PlayerLimitedLobby:PlayerCard
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
            this.name = "Lobby";
            this.playerOwner = owner;

            ActionLimitedPolitical tempAction = new ActionLimitedPolitical();
            tempAction.actionOwner = this;
            tempAction.gs = playerOwner.gs;
            tempAction.displayActionText = "Political Limited: If you have higher Family Honor than each other player, bow your target unbowed Personality with 1 or more Personal Honor to take the Imperial Favor.";

            EBowTargetCard bc = new EBowTargetCard();
            bc.effectTarget = new TargetYourPersonality();
            bc.effectCondition = new ConditionAtLeastOnePH();

            bc.cardOwner = this;
            bc.effectOwner = tempAction;

            tempAction.actionsEffects.Add(bc);

            EGainImperialFavour gf = new EGainImperialFavour();
            gf.cardOwner = this;
            gf.effectOwner = tempAction;

            tempAction.actionsEffects.Add(gf);

            this.cardAbilities.Add(tempAction);

            
        }

        public bool canBePerformed()
        {
            if (this.playerOwner.familyHonour > this.playerOwner.opposingPlayer.familyHonour)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}

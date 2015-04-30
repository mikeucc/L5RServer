using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class PlayerDynastyRecruit:PlayerCard
    {
        public override void createCard(Player owner)
        {
            this.playerOwner = owner;
            ActionDynastyRepeatable ad = new ActionDynastyRepeatable();
            ad.actionOwner = this;
            ad.gs = playerOwner.gs;


            ERecruitCardFromProvince ae = new ERecruitCardFromProvince();

            ae.effectOwner = ad;
            ae.cardOwner = this;

            ad.actionsEffects.Add(ae);
            ad.displayActionText = "Repeatable Dynasty,*: Bring into play a face-up Personality or Holding from your Prov- ince with Gold Cost equal to the amount you paid, paying 2 more Gold if the Personality has a Clan Alignment but does not have your Clan Alignment. (Holdings enter play bowed.) ";

            this.cardAbilities.Add(ad);
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

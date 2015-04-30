using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5R.Gamestate
{
    public class AM_027:Personality
    {
        public override void createCard(Player owner)
        {
            this.playerOwner = owner;

            this.name = "Kakita Ujirou";
            this.printedForce = 4;
            this.printedChi = 4;
            this.honorRequirement = 2;
            this.goldCost = 8;
            this.personalHonor = 3;
            this.canProduceGold = false;

            this.traits.Add(Gamestate.CraneClan);
            this.traits.Add(Gamestate.Magistrate);
            this.traits.Add(Gamestate.Reserve);
            this.traits.Add(Gamestate.Duelist);
            this.traits.Add(Gamestate.Samurai);
        }
    }
}

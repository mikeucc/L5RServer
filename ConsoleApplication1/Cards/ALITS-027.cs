using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5R.Gamestate
{
    public class ALITS_027:Personality
    {
        public override void createCard(Player owner)
        {
            this.playerOwner = owner;

            this.name = "Daidoji Takeda";
            this.printedChi = 2;
            this.printedForce = 2;
            this.honorRequirement = 2;
            this.goldCost = 4;
            this.personalHonor = 1;
            this.canProduceGold = false;

            this.traits.Add(Gamestate.CraneClan);
            this.traits.Add(Gamestate.Scout);
            this.traits.Add(Gamestate.Samurai);
            this.traits.Add(Gamestate.Resilient);


        }
    }
}

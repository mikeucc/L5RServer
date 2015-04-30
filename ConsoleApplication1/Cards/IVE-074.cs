using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5R.Gamestate
{
    public class IVE_074:Personality
    {
        public override void createCard(Player owner)
        {
            this.playerOwner = owner;

            this.name = "Daidoji Tanshi";
            this.printedForce = 3;
            this.printedChi = 3;
            this.honorRequirement = 5;
            this.goldCost = 4;
            this.personalHonor = 2;
            this.canProduceGold = false;

            this.traits.Add(Gamestate.CraneClan);
            this.traits.Add(Gamestate.Samurai);
            this.traits.Add(Gamestate.Scout);

        }
    }
}

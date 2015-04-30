using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class IVE_090:Personality    
    {
        public override void createCard(Player owner)
        {
            this.name = "Mirumoto Yasushi";
            this.printedChi = 4;
            this.printedForce = 4;
            this.honorRequirement = 4;
            this.goldCost = 9;
            this.personalHonor = 2;
            this.canProduceGold = false;
            this.traits.Add(Gamestate.DragonClan);
            this.traits.Add(Gamestate.Samurai);

            this.playerOwner = owner;
        }
    }
}

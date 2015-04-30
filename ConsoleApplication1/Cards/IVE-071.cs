using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class IVE_071:Personality
    {
        public override void createCard(Player owner)
        {
            this.playerOwner = owner;

            this.name = "Asahina Umeko";
            this.printedChi = 4;
            this.printedForce = 0;
            this.honorRequirement = 0;
            this.goldCost = 4;
            this.personalHonor = 2;
            this.canProduceGold = false;

            this.traits.Add(Gamestate.Shugenja); 
            this.traits.Add(Gamestate.CraneClan);
            this.traits.Add(Gamestate.Air);
        }
    }
}

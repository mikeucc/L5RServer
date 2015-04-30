using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class IVE_084:Personality
    {
        public override void createCard(Player owner)
        {
            
            this.printedForce = 3;
            this.printedChi = 3;
            this.honorRequirement = 3;
            this.goldCost = 4;
            this.personalHonor = 2;
            this.canProduceGold = false;
            this.traits.Add(Gamestate.Kensai);
            this.traits.Add(Gamestate.Samurai);
            this.traits.Add(Gamestate.DragonClan);
            this.playerOwner = owner;
            this.name = "Mirumoto Higaru";
          
            
        }
    }
}

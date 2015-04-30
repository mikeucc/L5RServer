using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class IVE_092:Personality
    {
        public override void createCard(Player owner)
        {
            this.playerOwner = owner;
            this.printedChi = 3;
            this.printedForce = 2;
            this.honorRequirement = 8;
            this.goldCost = 5;
            this.personalHonor = 3;
            this.canProduceGold = false;
            this.traits.Add(Gamestate.DragonClan);
            this.traits.Add(Gamestate.Shugenja);
            this.traits.Add(Gamestate.Earth);
            this.traits.Add(Gamestate.Cavalry);
            this.traits.Add(Gamestate.Mountaineer);

            
        }
    }
}

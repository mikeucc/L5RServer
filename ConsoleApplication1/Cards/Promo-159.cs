using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5R.Gamestate
{
    public class Promo_159:Holding
    {
        public override void createCard(Player owner)
        {
            this.playerOwner = owner;
            this.name = "Travelling Market";
            this.goldCost = 3;
            this.goldProduction = 3;
            this.canProduceGold = true;

            this.traits.Add(Gamestate.Kharmic);
            this.traits.Add(Gamestate.Market);
        }
    }
}

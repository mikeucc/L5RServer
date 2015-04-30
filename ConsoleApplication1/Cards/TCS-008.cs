using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5R.Gamestate
{
    public class TCS_008:Holding
    {
        public override void createCard(Player owner)
        {
            this.playerOwner = owner;

            this.name = "Cloth Market";
            this.goldCost = 5;
            this.goldProduction = 5;
            this.canProduceGold = true;

            this.traits.Add(Gamestate.Kharmic);
            this.traits.Add(Gamestate.Market);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5R.Gamestate
{
    public class AM_010:Holding
    {
        public override void createCard(Player owner)
        {
            this.playerOwner = owner;
            this.name = "House of Prophecy";
            this.goldCost = 4;
            this.goldProduction = 3;
            this.canProduceGold = true;

            this.traits.Add(Gamestate.Destined);
            this.traits.Add(Gamestate.Temple);
        }
    }
}

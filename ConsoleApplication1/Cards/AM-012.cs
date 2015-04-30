using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5R.Gamestate
{
    public class AM_012:Holding
    {
        public override void createCard(Player owner)
        {
            this.playerOwner = owner;
            this.name = "Productive Mine";
            this.goldCost = 4;
            this.goldProduction = 4;
            this.canProduceGold = true;

            this.traits.Add(Gamestate.Kharmic);
            this.traits.Add(Gamestate.Mine);
        }
    }
}

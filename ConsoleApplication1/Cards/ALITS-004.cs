using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5R.Gamestate
{
    public class ALITS_004:Holding
    {
        public override void createCard(Player owner)
        {
            this.playerOwner = owner;

            this.name = "Coastal Lane";
            this.goldCost = 4;
            this.goldProduction = 5;
            this.canProduceGold = true;

            this.traits.Add(Gamestate.Port);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5R.Gamestate
{
    public class AM_022:Personality
    {
        public override void createCard(Player owner)
        {
            this.playerOwner = owner;

            this.name = "Asahina Umehiko";
            this.personalHonor = 3;
            this.goldCost = 5;
            this.honorRequirement = 6;
            this.printedChi = 2;
            this.printedForce = 2;
            this.canProduceGold = false;

            this.traits.Add(Gamestate.CraneClan);
            this.traits.Add(Gamestate.Shugenja);
            this.traits.Add(Gamestate.Air);
            this.traits.Add(Gamestate.Expendable);
        }
    }
}

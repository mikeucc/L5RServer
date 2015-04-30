using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5R.Gamestate
{
    public class TCS_031:Personality
    {
        public override void createCard(Player owner)
        {
            this.playerOwner = owner;

            this.name = "Kakita Mitohime";
            this.printedChi = 3;
            this.printedForce = 3;
            this.honorRequirement = 6;
            this.goldCost = 6;
            this.personalHonor = 3;

            this.traits.Add(Gamestate.CraneClan);
            this.traits.Add(Gamestate.Destined);
            this.traits.Add(Gamestate.Duelist);
            this.traits.Add(Gamestate.Magistrate);
            this.traits.Add(Gamestate.Samurai);
            this.traits.Add(Gamestate.Imperial);
        }

       
    }
}

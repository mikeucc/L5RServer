using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class IVE_366: Stronghold
    {
        public override void createCard(Player owner)
        {
            this.playerOwner = owner;
            this.baseStrength = 6;
            this.goldProduction = 4;
            this.startingFamilyHonor = 5;
            this.canProduceGold = true;

            this.traits.Add(Gamestate.DragonClan);
            this.traits.Add(Gamestate.Temple);

            this.numOfStartingProvinces = 4;

            this.family = Gamestate.DragonClan;
        }
    }
}

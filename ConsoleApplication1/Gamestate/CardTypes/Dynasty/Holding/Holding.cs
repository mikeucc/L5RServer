using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class Holding: DynastyCard
    {
        public int goldCost { get; set; }
        public int goldProduction { get; set; }

        // Not implimented
        public override Boolean canBeRecruitedBy(Player p)
        {
            return true;
        }

        //Not implimented
        public override void handleEventsPhase(Gamestate gs)
        {

        }

        public void produceGold()
        {
            this.IsBowed = true;
            this.playerOwner.goldPool += this.goldProduction;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class Stronghold: Card
    {
        
        public int baseStrength { get; set; }
        public int goldProduction { get; set; }
        public int startingFamilyHonor { get; set; }
        public List<IAction> shActions { get; set; }
        //This is 99% of the time 4, but there have be stronghold that modified this in the past
        public int numOfStartingProvinces { get; set; }

        public string family { get; set; }

        public Stronghold()
        {
            
        }

        public override bool canBeRecruitedBy(Player p)
        {
            throw new NotImplementedException();
        }

        public override void getDiscardedBy(Player p)
        {
            throw new NotImplementedException();
        }
    }
}

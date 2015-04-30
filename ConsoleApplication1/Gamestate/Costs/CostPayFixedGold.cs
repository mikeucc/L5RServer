using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class CostPayFixedGold:ICost
    {
        public int goldCost { get; set; }
        
        public override void payCosts(Gamestate gs, Card cardPerformingAction)
        {
            base.payCosts(gs, cardPerformingAction);
            gs.performingPlayer.payGoldCost(goldCost);
        }
    }
}

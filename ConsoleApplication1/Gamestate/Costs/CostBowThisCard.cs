using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class CostBowThisCard:ICost
    {
        public override void payCosts(Gamestate gs, Card cardPerformingAction)
        {
            base.payCosts(gs, cardPerformingAction);
            cardPerformingAction.IsBowed = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public abstract class DynastyCard : Card
    {
        override public void getDiscardedBy(Player p)
        {
            p.pDynastyDiscard.addCardToDiscard(this);
        }

        public abstract void handleEventsPhase(Gamestate gs);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public abstract class FateCard:Card
    {
        override public void getDiscardedBy(Player p)
        {
            p.pFateDiscard.addCardToDiscard(this);
        }

        public int focusValue { get; set; }

    }
}

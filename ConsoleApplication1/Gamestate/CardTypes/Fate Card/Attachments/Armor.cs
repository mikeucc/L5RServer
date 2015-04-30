using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class Armor: Attachment
    {
        public override void getDiscardedBy(Player p)
        {
            p.pFateDiscard.addCardToDiscard(this);
        }
    }
}

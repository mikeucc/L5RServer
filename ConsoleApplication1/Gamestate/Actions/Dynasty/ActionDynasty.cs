using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class ActionDynasty:IAction
    {
        public override bool canBePerformed()
        {
            if (this.actionOwner.IsBowed || this.actionPerformed|| !gs.activePlayer.Equals(this.actionOwner.playerOwner) ||!gs.isDynastyPhase)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

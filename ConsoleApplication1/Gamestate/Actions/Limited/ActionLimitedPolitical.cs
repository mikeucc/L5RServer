using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class ActionLimitedPolitical:IAction
    {
        public override bool canBePerformed()
        {
            if (!this.actionOwner.playerOwner.Equals(gs.activePlayer) || this.actionPerformed || this.actionOwner.IsBowed || !gs.isActionPhase)
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

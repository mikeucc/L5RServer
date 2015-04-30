using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class ActionLimitedReapatable:IAction
    {
        public override bool canBePerformed()
        {
            if (!this.actionOwner.playerOwner.Equals(gs.activePlayer) || this.actionOwner.IsBowed || !gs.isActionPhase)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

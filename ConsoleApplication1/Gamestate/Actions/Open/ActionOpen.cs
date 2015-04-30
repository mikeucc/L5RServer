using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class ActionOpen:IAction
    {
        public override bool canBePerformed()
        {
            if (this.actionOwner.IsBowed || this.actionPerformed || !gs.isActionPhase)
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

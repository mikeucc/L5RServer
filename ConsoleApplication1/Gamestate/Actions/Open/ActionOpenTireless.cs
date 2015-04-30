using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class ActionOpenTireless:IAction
    {
        public override bool canBePerformed()
        {
            if (this.actionPerformed || !gs.isActionPhase)
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

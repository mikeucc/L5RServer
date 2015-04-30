using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class ActionOpenRepeatableTireless:IAction
    {
        public override bool canBePerformed()
        {
            
            if (!gs.isActionPhase)
                return false;
            else
                return true;
        }
    }
}

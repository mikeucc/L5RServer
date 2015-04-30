using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class ActionEngageAbsent:IAction
    {
        public override bool canBePerformed()
        {
            //Nothign should stop you performing these action types
            if (!gs.isBattlePhase)
                return false;
            else
                return true;
        }
    }
}

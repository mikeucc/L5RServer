using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class ActionAbsentBattle:IAction
    {
        public override bool canBePerformed()
        {
            
            if (!gs.isBattlePhase)
                return false;
            else
                return true;
        }
    }
}

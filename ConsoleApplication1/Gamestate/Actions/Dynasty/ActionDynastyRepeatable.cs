using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class ActionDynastyRepeatable:IAction
    {
        public override bool canBePerformed()
        {
            Console.WriteLine(this.actionOwner.IsBowed+" "+this.actionOwner.playerOwner.aLabel+" "+gs.isDynastyPhase);
            if (this.actionOwner.IsBowed || !gs.activePlayer.Equals(this.actionOwner.playerOwner) || !gs.isDynastyPhase)
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

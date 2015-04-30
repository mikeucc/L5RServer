using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class ActionInterrupt:IAction
    {
        

        public IAction cardsToBeInterrupted { get; set; }

        public override bool canBePerformed()
        {
            if (gs.currentActionBeingPlayed==null)
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

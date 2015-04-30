using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class ActionBattleTireless:IAction
    {
        public override bool canBePerformed()
        {
            if (gs.currentBattlefield.myCards(this.actionOwner.playerOwner).Count == 0 || this.actionPerformed || !gs.isBattlePhase)
            {
                //you have no units at current battlefield so cannot play these action types
                return false;
            }
            else
            {
                if (this.actionOwner is Personality || this.actionOwner is Attachment)
                {
                    if (gs.currentBattlefield.isCardHere(this.actionOwner.playerOwner, this.actionOwner))
                    {
                        //While the action is playable it is not present at battlefield so cannot be used
                        return false;
                    }
                }
                return true;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class ActionEngage:IAction
    {
        public override bool canBePerformed()
        {
            if (gs.currentBattlefield.myCards(gs.performingPlayer).Count < 1 || !gs.isBattlePhase)
            {
                //you have no units here so cannot perform an engage action
                return false;
            }
            else
            {
                //Are these cards actuall at the battlefield
                if (this.actionOwner is Personality || this.actionOwner is Attachment)
                {
                    if (gs.currentBattlefield.isCardHere(this.actionOwner.playerOwner, this.actionOwner))
                    {
                        //While the action is playable it is not present at battlefield so cannot be used
                        return false;
                    }
                }
                //you have presence and cards are there that need to be
                return true;
            }

        }
    }
}

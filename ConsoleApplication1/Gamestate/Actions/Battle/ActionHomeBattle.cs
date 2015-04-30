using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class ActionHomeBattle:IAction
    {
        public override bool canBePerformed()
        {
            if (gs.currentBattlefield.myCards(this.actionOwner.playerOwner).Count == 0 || this.actionPerformed || !gs.isBattlePhase||this.actionOwner.IsBowed)
            {
                //you have no units at current battlefield so cannot play these action types
                return false;
            }
            else
            {
                //Its a home action so no need to check the cards location
                //Will need a rules clarification on this.
                return true;
            }
        }
    }
}

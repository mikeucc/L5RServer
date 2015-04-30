using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class ConditionLessProvinceThanOpponent:ICondition
    {
        public override bool doesCardMeetCondition(Card crd)
        {

            if (crd.playerOwner.playerProvinces.Count < crd.playerOwner.opposingPlayer.playerProvinces.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

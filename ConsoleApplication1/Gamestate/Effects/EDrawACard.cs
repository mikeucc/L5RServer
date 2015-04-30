using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class EDrawACard:IEffect
    {
        public override bool applyEffects(Gamestate gs)
        {
            
            gs.performingPlayer.pHand.addCardToHand(gs.performingPlayer.pFateDeck.drawTopCard());
                     
            return true;
        }
    }
}

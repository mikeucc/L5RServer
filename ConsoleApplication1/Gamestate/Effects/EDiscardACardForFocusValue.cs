using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class EDiscardACardForFocusValue:IEffect
    {
        public override bool applyEffects(Gamestate gs)
        {
            bool returnValue = true;
            int numCardsinDiscard = gs.performingPlayer.pFateDiscard.numberOfCardsDiscarded();

            
            FateCard fCard=(FateCard)gs.pickTarget(this.effectTarget.returnTargetList(gs, this.effectCondition),gs.performingPlayer);
            try
                {
                    gs.performingPlayer.pHand.discardCard(fCard);
                    this.effectOwner.focusValueDiscard = fCard.focusValue;
                    gs.performingPlayer.pFateDiscard.addCardToDiscard(fCard);
                }
                catch
                {
                }
            
            if (gs.performingPlayer.pFateDiscard.numberOfCardsDiscarded() > numCardsinDiscard)
            {
                returnValue = true;
            }
            else
            {
                returnValue = false;
            }
            gs.performingPlayer = gs.getOpposingPlayer(gs.performingPlayer);
            return returnValue;
        }
    }
}

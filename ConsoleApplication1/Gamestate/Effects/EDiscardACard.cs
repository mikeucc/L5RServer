using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class EDiscardACard:IEffect
    {
        public override bool applyEffects(Gamestate gs)
        {
            bool returnValue = true;
            int numCardsinDiscard = gs.performingPlayer.pFateDiscard.numberOfCardsDiscarded();

            foreach (Card crd in gs.pickTargets(this.effectTarget.returnTargetList(gs, this.effectCondition), this.effectTarget.numOfTargets, gs.performingPlayer))
            {
                try
                {
                    gs.performingPlayer.pHand.discardCard((FateCard)crd);
                    gs.performingPlayer.pFateDiscard.addCardToDiscard((FateCard)crd);
                }
                catch
                {
                }
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

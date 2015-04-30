using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class EDynastyMuligan:IEffect
    {
        public override bool applyEffects(Gamestate gs)
        {
            foreach (Province prov in gs.performingPlayer.playerProvinces)
            {
                foreach (Card crd in gs.pickTargets(this.effectTarget.returnTargetList(gs, this.effectCondition), this.effectTarget.numOfTargets, gs.performingPlayer))
                {
                    if (crd.Equals(prov.purchasableCard))
                    {
                        gs.performingPlayer.pDynastyDeck.addCardsToDeck(prov.purchasableCard);
                        prov.purchasableCard = gs.performingPlayer.pDynastyDeck.drawTopCard();
                        prov.purchasableCard.IsFaceDown = false;
                    }
                }
            }
            return true;
        }
    }
}

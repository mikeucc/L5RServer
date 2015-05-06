using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class ERefillProvince:IEffect
    {
        public override bool applyEffects(Gamestate gs)
        {
            try
            {
                Card selectedCard = gs.pickTarget(new TargetACardInYourProvince().returnTargetList(gs, this.effectCondition), gs.performingPlayer);

                foreach (Province pv in gs.performingPlayer.playerProvinces)
                {
                    if (pv.purchasableCard.Equals(selectedCard))
                    {
                        gs.performingPlayer.pDynastyDiscard.addCardToDiscard(pv.purchasableCard);
                        pv.purchasableCard = gs.performingPlayer.pDynastyDeck.drawTopCard();
                    }
                }
            }
            catch
            {
                Console.WriteLine("Invalid gamestate: ERefillProvince");
            }
            gs.performingPlayer = gs.getOpposingPlayer(gs.performingPlayer);
            return true;
        }
    }
}

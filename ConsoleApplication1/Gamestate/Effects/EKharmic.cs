using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class EKharmic:IEffect
    {
        public override bool applyEffects(Gamestate gs)
        {
            
            List<Card> selectedTargets= gs.pickTargets(new TargetYourCardInHandOrProvince().returnTargetList(gs, new ConditionTypeKharmic()), 1, gs.performingPlayer);

            foreach (Card crd in selectedTargets)
            {
                if (crd is FateCard)
                {
                    try
                    {
                        gs.performingPlayer.pFateDiscard.addCardToDiscard(gs.performingPlayer.pHand.discardCard((FateCard)crd));
                        gs.performingPlayer.pHand.addCardToHand(gs.performingPlayer.pFateDeck.drawTopCard());
                    }
                    catch
                    {
                    }
                }
                else
                {
                    // Card is a dynasty Deck
                    foreach (Province pv in gs.performingPlayer.playerProvinces)
                    {
                        if(pv.purchasableCard.Equals(crd))
                        {
                            try
                            {
                                gs.performingPlayer.pDynastyDiscard.addCardToDiscard((DynastyCard)crd);
                                pv.purchasableCard = gs.performingPlayer.pDynastyDeck.drawTopCard();
                                pv.purchasableCard.IsFaceDown = false;
                            }
                            catch
                            {

                            }
                        }
                    }
                }


            }
            gs.performingPlayer = gs.getOpposingPlayer(gs.performingPlayer);
            return true;
        }

        public override bool canBePlayed(Gamestate gs)
        {
            try
            {
                foreach (Card crd in gs.performingPlayer.pHand.getCardsInHand())
                {
                    if(crd.traits.Contains(Gamestate.Kharmic))
                    {
                        return true;
                    }
                }

                foreach(Card crd in gs.performingPlayer.cardsInPlay)
                {
                    if(crd.traits.Contains(Gamestate.Kharmic))
                    {
                        return true;
                    }
                }
            }
            catch
            {
            }

            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class ERecruitCardFromProvince:IEffect
    {
        public override bool applyEffects(Gamestate gs)
        {

            //
            Province targetProv=gs.pickProvince(this.canBePurchasedFromProvince(gs),gs.activePlayer);
            
            
            //Check loyalist restrictions/family honour requirments in the canBeRecruitedBy(this)
            //
            if (targetProv.purchasableCard.canBeRecruitedBy(gs.activePlayer))
            {
                int goldCostModifier = 0;

                if (targetProv.purchasableCard.traits.Contains(gs.performingPlayer.stronghold.family))
                {
                    goldCostModifier = 2;
                }
                if (targetProv.purchasableCard.getCardCost()+goldCostModifier <= gs.activePlayer.goldPool)
                {
                    gs.activePlayer.goldPool -= targetProv.purchasableCard.getCardCost()+goldCostModifier;
                    targetProv.purchasableCard.enteringPlay();
                    gs.activePlayer.cardsInPlay.Add(targetProv.purchasableCard);
                    //refill province
                    
                    try
                    {
                        targetProv.purchasableCard = gs.performingPlayer.pDynastyDeck.drawTopCard();
                        targetProv.purchasableCard.IsFaceDown = true;
                    }
                    catch
                    {
                        Console.WriteLine("No cards left in dynasty deck");
                    }
                }
            }
            gs.performingPlayer = gs.getOpposingPlayer(gs.performingPlayer);
            return true;

        }

        

        //Gets a list of provencies who's purchasable card is either a holding or personality
        public List<Province> canBePurchasedFromProvince(Gamestate gs)
        {
            List<Province> returnList = new List<Province>();
            foreach (Province pv in gs.activePlayer.playerProvinces)
            {
                if ((pv.purchasableCard is Holding && !pv.purchasableCard.IsFaceDown) || (pv.purchasableCard is Personality && !pv.purchasableCard.IsFaceDown))
                {
                    returnList.Add(pv);
                }
            }
            return returnList;
        }
    }
}

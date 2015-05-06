using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class ECycle:IEffect
    {
        public override bool applyEffects(Gamestate gs)
        {
            List<Card> selectedCards = new List<Card>();

            selectedCards = gs.pickTargets(this.effectTarget.returnTargetList(gs,this.effectCondition), 4, gs.performingPlayer);

            foreach (DynastyCard crd in selectedCards)
            {
                Console.WriteLine("Selected target: "+crd.name);
                foreach (Province pv in gs.performingPlayer.playerProvinces)
                {
                    if (pv.purchasableCard.Equals(crd))
                    {
                        pv.refillProvince();
                        gs.performingPlayer.pDynastyDeck.addCardsToDeck(crd);
                        pv.purchasableCard.IsFaceDown = false;
                    }
                }
            }

            foreach (Province pv in gs.performingPlayer.playerProvinces)
            {
                
                    Console.WriteLine("Card Name:" + pv.purchasableCard.name);
                    Console.WriteLine("Is Face down:" + pv.purchasableCard.IsFaceDown.ToString());
               
            }
            gs.performingPlayer = gs.getOpposingPlayer(gs.performingPlayer);
            return true;
        }
    }
}

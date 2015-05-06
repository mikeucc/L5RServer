using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class ESendUnitHome:IEffect
    {
        public override bool applyEffects(Gamestate gs)
        {

            bool returnValue = true;
            foreach(Personality per in gs.pickTargets(this.effectTarget.returnTargetList(gs,this.effectCondition),this.effectTarget.numOfTargets,gs.performingPlayer))
            {
                if (this.effectOwner.willMove == true)
                {
                    per.playerOwner.cardsInPlay.Add(per);
                    gs.currentBattlefield.myCards(per.playerOwner).Remove(per);
                    returnValue = true;
                }
                else
                {
                    returnValue = false;
                }
            }
            gs.performingPlayer = gs.getOpposingPlayer(gs.performingPlayer);
            return returnValue;
        }
    }
}

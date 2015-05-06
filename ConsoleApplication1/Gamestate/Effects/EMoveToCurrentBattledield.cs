using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5R.Gamestate
{
    public class EMoveToCurrentBattledield:IEffect
    {
        public override bool applyEffects(Gamestate gs)
        {
            if (this.effectOwner.targetsSelected)
            {

                foreach (Card crd in this.effectOwner.selectedTargets)
                {
                    Personality per = (Personality)crd;
                    //Move the card from home
                    per.playerOwner.pHome.removeCardFromPlay(per);

                    //Move the card from a battlefield
                    foreach (Battlefield bf in gs.allBattlefields)
                    {
                        bf.removeUnitFromBattlefield(per);
                    }

                    //To the current battlefield
                    gs.currentBattlefield.moveUnitToBattleField(per);
                }
                gs.performingPlayer = gs.getOpposingPlayer(gs.performingPlayer);
                return true;
            }
            else
            {
                this.effectOwner.selectedTargets=gs.pickTargets(this.effectTarget.returnTargetList(gs, this.effectCondition), this.effectTarget.numOfTargets, this.effectOwner.actionOwner.playerOwner);
                this.effectOwner.targetsSelected = true;
                this.applyEffects(gs);
            }
            gs.performingPlayer = gs.getOpposingPlayer(gs.performingPlayer);
            return false;
        }
    }
}

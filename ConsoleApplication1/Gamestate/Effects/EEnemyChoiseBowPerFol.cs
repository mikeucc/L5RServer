using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class EEnemyChoiseBowPerFol:IEffect
    {
        public override bool applyEffects(Gamestate gs)
        {
            TargetEnemyPersonalityFollower tar =new TargetEnemyPersonalityFollower();
            List<Card> chosenTar=gs.pickTargets(tar.returnTargetList(gs, new ConditionStatusUnbowed()), this.effectTarget.numOfTargets, gs.performingPlayer.opposingPlayer);
            foreach (Card crd in chosenTar)
            {
                crd.IsBowed = true;
            }
            return true;
        }
    }
}
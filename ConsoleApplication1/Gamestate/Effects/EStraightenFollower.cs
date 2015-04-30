using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class EStraightenAttachment:IEffect
    {
        public override bool applyEffects(Gamestate gs)
        {
            bool returnValue = true;

            foreach (Attachment att in gs.pickTargets(this.effectTarget.returnTargetList(gs, this.effectCondition), this.effectTarget.numOfTargets, gs.performingPlayer))
            {
                if (att.IsBowed == false)
                {
                    returnValue = false;
                }
                
                att.IsBowed = false;
            }

            return returnValue;
        }
    }
}

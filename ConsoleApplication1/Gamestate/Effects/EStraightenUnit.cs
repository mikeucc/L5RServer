using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5R.Gamestate
{
    public class EStraightenUnit:IEffect
    {
        public override bool applyEffects(Gamestate gs)
        {
            foreach (Card crd in this.effectOwner.selectedTargets)
            {
                Personality per = (Personality)crd;
                per.straightenUnit();
            }
            return true;
        }
    }
}

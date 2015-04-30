using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public abstract class ITarget
    {
        public virtual List<Card> returnTargetList(Gamestate gs,ICondition cond)
        {
            return null;
        }

        public int numOfTargets { get; set; }
    }
}

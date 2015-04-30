using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public abstract class ICost
    {
        public ICost()
        {
        }

        public bool costPaid { get; set; }

        public virtual void payCosts(Gamestate gs,Card cardPerformingAction)
        {

        }
    }
}

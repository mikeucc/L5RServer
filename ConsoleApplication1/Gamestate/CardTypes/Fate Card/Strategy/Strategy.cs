using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class Strategy:FateCard
    {
        public override bool canBeRecruitedBy(Player p)
        {
            return false;
        }
    }
}

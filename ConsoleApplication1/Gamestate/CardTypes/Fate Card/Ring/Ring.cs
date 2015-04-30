using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class Ring:FateCard
    {
        public override Boolean canBeRecruitedBy(Player p)
        {
            return true;
        }
    }
}

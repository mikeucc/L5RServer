using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class Weapon:Item
    {
        public override Boolean canBeRecruitedBy(Player p)
        {
            return true;
        }
    }
}

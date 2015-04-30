using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class Item: Attachment
    {
        // There generic item cards
        //However there are also 2 subtypes Armor and weapons, which have restrictions on how many you can attach

        //Not implimented.
        public override Boolean canBeRecruitedBy(Player p)
        {
            return true;
        }
    }
}

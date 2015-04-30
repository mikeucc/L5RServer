using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class ICondition
    {
        public virtual bool doesCardMeetCondition(Card crd)
        {
            return true;
        }

        public Gamestate gs { get; set; }
        public IEffect conditionOwner { get; set; }
        public Personality personalityOwner { get; set; }
        public Holding holdingOwner { get; set; }
        public L5R.Gamestate.EventCard eventOwner { get; set; }
        public Follower followerOwner { get; set; }
        public Item itemOwner { get; set; }
        public Armor armorOwner { get; set; }
        public Weapon weaponOwner { get; set; }
        public Spell spellOwner { get; set; }
        public Ring ringOwner { get; set; }
    }
}

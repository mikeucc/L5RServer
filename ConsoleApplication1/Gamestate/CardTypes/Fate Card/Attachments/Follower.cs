using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class Follower: Attachment
    {
        
               

        public override bool canBeRecruitedBy(Player p) {
            throw new NotImplementedException();
        }

        public override void getDiscardedBy(Player p) 
        {
            p.pFateDiscard.addCardToDiscard(this);
        }

        
    }
}

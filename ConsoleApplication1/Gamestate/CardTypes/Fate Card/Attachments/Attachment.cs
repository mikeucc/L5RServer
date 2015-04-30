using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class Attachment: FateCard
    {
        //All Attachments are fate cards
        int goldCost { get; set; }
        public Personality attachedTo { get; set; }
        

        // not sure if I need this
        public void destroyAttachment()
        {

        }

        public override void getDiscardedBy(Player p)
        {
            p.pFateDiscard.addCardToDiscard(this);
        }

        public override Boolean canBeRecruitedBy(Player p)
        {
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class ERecruitAttachment:IEffect
    {
         

        public override bool applyEffects(Gamestate gs)
        {
            
            
            //This is horrible. it will work. But it is not ideal
            //What I really want is Attachment att=selectedTarget.Find(Where type is Attachment) or something along those lines
            try
            {
                Personality targetPersonality = (Personality)gs.pickTargets(new TargetYourPersonality().returnTargetList(gs, new ConditionNull()), 1, gs.performingPlayer)[0];
                Attachment targetAttachment = (Attachment)gs.pickTargets(this.effectTarget.returnTargetList(gs, this.effectCondition), this.effectTarget.numOfTargets, gs.performingPlayer)[0];

                if (targetAttachment.canBeRecruitedBy(gs.performingPlayer) && targetPersonality.canAttachAttachment(targetAttachment))
                {
                    gs.performingPlayer.pHand.discardCard(targetAttachment);
                    targetPersonality.addAttachment(targetAttachment);
                }
            }
            catch
            {
                Console.WriteLine("No legal targets");
            }

            return true;
        }
    }
}
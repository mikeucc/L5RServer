using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class PlayerRecruitInterruptPass:PlayerCard
    {
        
        public override void createCard(Player owner)
        {
            this.playerOwner = owner;
            

            ActionRecruitInterrupt tempAction = new ActionRecruitInterrupt();
            tempAction.gs = playerOwner.gs;
            tempAction.displayActionText = "Recruit Interrupt: Pass";
            EPass tempEffect = new EPass();


            tempEffect.effectOwner = tempAction;
            tempAction.actionsEffects.Add(tempEffect);
            tempAction.actionOwner = this;

            this.cardAbilities.Add(tempAction);
        }
    }
}

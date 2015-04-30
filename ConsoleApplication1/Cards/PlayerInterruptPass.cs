using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class PlayerInterruptPass:PlayerCard
    {
        public override void createCard(Player owner)
        {
            this.playerOwner = owner;

            ActionInterrupt tempAction = new ActionInterrupt();
            tempAction.gs = playerOwner.gs;
            EPass tempEffect = new EPass();


            tempEffect.effectOwner = tempAction;
            tempAction.actionsEffects.Add(tempEffect);
            tempAction.actionOwner = this;
            tempAction.displayActionText = "Interrupt: Pass";
            this.cardAbilities.Add(tempAction);
        }
    }
}

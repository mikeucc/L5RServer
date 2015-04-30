using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class PlayerDynastyPass:PlayerCard 
    {
        public override void createCard(Player owner)
        {
            this.playerOwner = owner;

            ActionDynasty tempAction = new ActionDynasty();
            tempAction.gs = playerOwner.gs;
            EPass tempEffect = new EPass();


            tempEffect.effectOwner = tempAction;
            tempAction.actionsEffects.Add(tempEffect);
            tempAction.actionOwner = this;
            tempAction.displayActionText = "Dynasty: Pass";

            this.cardAbilities.Add(tempAction);
        }
    }
}

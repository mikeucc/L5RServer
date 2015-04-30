using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class IVE_008:Holding
    {
        public override void createCard(Player owner)
        {
            this.name = "Akodo Dojo";
            this.goldProduction = 2;
            this.canProduceGold = true;
            
            EBowThisCard tempEffect=new EBowThisCard();
            tempEffect.cardOwner=this;
            this.enteringPlayEffects.Add(tempEffect);

            ActionRecruitInterrupt tempAction=new ActionRecruitInterrupt();

            tempAction.actionOwner = this;

            EBowThisCard te3 = new EBowThisCard();
            te3.cardOwner = this;
            te3.effectOwner = tempAction;
            tempAction.actionsEffects.Add(te3);

            
            ERecruitCostModificationFollower tempEffect2 = new ERecruitCostModificationFollower();
            tempEffect2.cardOwner = this;
            tempEffect2.effectOwner = tempAction;
            tempEffect2.conditionalModifierValue= -3;
            tempAction.actionsEffects.Add(tempEffect2);

            this.recruitInterrupts.Add(tempAction);

            //this.recruitInterrupts.Add(
            
           
        }
    }
}

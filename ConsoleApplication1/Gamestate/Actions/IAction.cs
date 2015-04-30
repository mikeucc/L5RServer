using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public abstract class IAction
    {

        //Most actions just target 1 card. But if it targets multible cards. The first will be the performers then there will be the opponen
        public List<TargetConditionStruct> targetAndConditions;
        public List<IEffect> actionsEffects;

        public Card actionOwner { get; set; }

        //Easy was to impliment negation interrupts
        public bool willDestroy { get; set; }
        public bool willBow { get; set; }
        public bool willMove { get; set; }
        public bool willstraighten { get; set; }
        public bool willDishonour { get; set; }
        public bool willRehonour { get; set; }
        public int modifyForce { get; set; }
        public int modifyChi { get; set; }
        public int modifyRanged { get; set; }
        public int modifyMelee { get; set; }
        public int modifyGoldCost { get; set; }
        public int modifyGoldCostFollower { get; set; }
        public int modifyGoldCostAttachment { get; set; }
        public int modifyGoldCostItem { get; set; }
        public int modifyGoldCostWeapon { get; set; }
        public int modifyGoldCostSpell { get; set; }
        public int modifyGoldCostHolding { get; set; }
        public int modifyGoldCostPersonality { get; set; }
        public int modifyGoldCostArmor { get; set; }
        public int previousEffectValue { get; set; }
        public string displayActionText { get; set; }
        public bool actionPerformed { get; set; }
        public int focusValueDiscard { get; set; }
        public bool targetsSelected { get; set; }


        //For gui selection calls
        public Gamestate gs { get; set; }


        public IAction()
        {
            actionsEffects = new List<IEffect>();
            targetAndConditions = new List<TargetConditionStruct>();
            targetsSelected = false;
        }

        public IAction(List<TargetConditionStruct> targetAndConditions,Card owner)
        {
            this.targetAndConditions = targetAndConditions;
            this.actionOwner = owner;

        }

        public List<Card> selectedTargets;
        
        
          
        //returns true if the action can be performed. If the parent card is bowed or the action has already been used this would return false
        public virtual bool canBePerformed()
        {
            if (this.actionOwner.IsBowed)
            {
                return false;
            }
            if (this.actionPerformed)
            {
                return false;
            }
            
            return true;
        }

        
        
        //Announce that ability is to be used
        public void announceAction()
        {

        }

        
        //Interrupts to the actions can now be played , they usually modify the actions effects
        public virtual void playInterrupts()
        {
            gs.performingPlayer.InterruptHasPassed = false;
            gs.performingPlayer.opposingPlayer.InterruptHasPassed = false;

            while (!gs.performingPlayer.InterruptHasPassed && !gs.performingPlayer.opposingPlayer.InterruptHasPassed)
            {
                gs.performingPlayer.performInterrupt(gs.performingPlayer.pickInterrupt(gs.performingPlayer.getListOfInterrupts(this, gs.currentBattlefield)));
                gs.performingPlayer.opposingPlayer.performInterrupt(gs.performingPlayer.opposingPlayer.pickInterrupt(gs.performingPlayer.opposingPlayer.getListOfInterrupts(this, gs.currentBattlefield)));
            }

            //After interrupts have been played reset has passed
            gs.performingPlayer.InterruptHasPassed = false;
            gs.performingPlayer.opposingPlayer.InterruptHasPassed = false;
        }


        public virtual void playRecruitInterrupts()
        {
            gs.performingPlayer.InterruptHasPassed = false;

            while (!gs.performingPlayer.InterruptHasPassed)
            {
                gs.performingPlayer.performInterrupt(gs.performingPlayer.pickInterrupt(gs.performingPlayer.getActionRecruitInterrupt()));
            }
        }

        //Pay cost of action. Either that card this ability is on bow or pay gold
        public virtual void payActionCosts()
        {
        }


        //Resolve effects, this is where things are targeted and effects are applied
        public virtual void resolveEffects()
        {
            Console.WriteLine("Number of effects:" + this.actionsEffects.Count.ToString());
            foreach (IEffect eff in this.actionsEffects)
            {
                Console.WriteLine("Resolve effects loop");
                eff.applyEffects(gs);
            }
        }

        //is the interrupt that could be played valid
        public virtual bool isValidInterrupt(ActionInterrupt interrupt)
        {
            return true;
        }

    }
}

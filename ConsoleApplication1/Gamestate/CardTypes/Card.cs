using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public abstract class Card
    {
        #region Variables
        public List<IEffect> enteringPlayEffects { get; set; }
        public List<IEffect> leavingPlayEffects { get; set; }
        public List<IAction> recruitInterrupts { get; set; }
        public List<IAction> cardAbilities;
        public List<string> traits { get; set; }
        public List<string> tempTraits { get; set; }

        public String name { get; set; }
        public String imageName { get; set; }

        public bool IsBowed { get; set; }
        public bool canProduceGold { get; set; }
        public bool IsFaceDown { get; set; }
        
        public int tempforceModifier { get; set; }
        public int permForceModifier { get; set; }
        public int currentForce { get; set; }
        
        public Player playerOwner { get; set; }
 
        public Card()
        {
            IsBowed = false;
            //By default all cards are face down, including cards in hand
            turnFaceDown();
            cardAbilities = new List<IAction>();
            traits = new List<string>();
            tempTraits = new List<string>();
            enteringPlayEffects = new List<IEffect>();
            leavingPlayEffects = new List<IEffect>();
            recruitInterrupts = new List<IAction>();
        }
        #endregion

        #region Performed Actions
        public void straighten() 
        {
            IsBowed = false;
        }
        public void turnFaceUp() 
        {
            this.IsFaceDown = false;
        }
        public void turnFaceDown() 
        {
            this.IsFaceDown = true;
        }

        #region Virtual/Abstract Methods

        public virtual void destroyCard()
        {
            //Does nothing
        }

        //returns card cost after modifiers
        public virtual int getCardCost()
        {
            //does nothing at this level
            return 0;
        }

        public virtual void enteringPlay()
        {
            //run any entering play effects
            foreach (IEffect eff in enteringPlayEffects)
            {
                eff.applyEffects(playerOwner.gs);
            }
        }

        public virtual void leavingPlay()
        {
            //run and leaving play effects
        }

        /* Add self to appropriate discard pile. Overridden by FateCard and 
         * DynastyCard so that they get to choose where to go.
         * 
         * Note that this doesn't care whether Player p currently owns the card!
         */
        public abstract void getDiscardedBy(Player p);

        /* Can Player p recruit this card from a province?
         */
        public abstract Boolean canBeRecruitedBy(Player p);


        //public abstract String GetTextBox();

        public virtual void createCard(Player owner)
        {

        }
        #endregion

        #endregion
    }
}

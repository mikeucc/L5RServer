using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class Personality: DynastyCard
    {
        #region Variables
        public int honorRequirement { get; set; }
        public int goldCost {get; set;}
        public int personalHonor { get; set; }
        public int printedForce { get; set; }
        public int printedChi { get; set; }
        public int currentChi { get; set; }
        public bool isHonourable { get; set; }
        public bool isDead { get; set; }
        //A card is either Attacking, Defending or at home
        public string status;
        public List<Attachment> attachedCards { get; set; }
        public List<IAction> personalityAbilities { get; set; }
        public Battlefield assignedToThisBattfield { get; set; }
        
       

        public Personality()
        {
            attachedCards = new List<Attachment>();
            personalityAbilities = new List<IAction>();
            isHonourable = true;
            isDead = false;
            
        }
        #endregion

        #region Performed Actions
        public override void getDiscardedBy(Player p) {
            // Special behaviour for discarding personalities --- they don't live in the discard pile, right?
            // Personalited that have either been destroyed or discarded by the player/effects go into the dynasty discard
            // So same as any other card
            p.pDynastyDiscard.addCardToDiscard(this);
        }

        // Not implimented
        public override Boolean canBeRecruitedBy(Player p)
        {
            
            return true;
        }

        public override void enteringPlay()
        {
           if(this.traits.Contains(Gamestate.Destined))
           {
               this.playerOwner.pHand.addCardToHand(this.playerOwner.pFateDeck.drawTopCard());
           }
        }

        public void straightenUnit()
        {
            this.straighten();
            foreach (Attachment att in this.getAllAttachedCards())
            {
                att.straighten();
            }
        }

        public void destroyCardInUnit(Attachment cardToBeDestroyed)
        {
            // Add card to appropiate discard pile in this case all attachments are fate cards
            cardToBeDestroyed.getDiscardedBy(this.playerOwner);
            //remove card from list of attachments 
            // Should this be here or in the getDiscardBy object ?
            this.attachedCards.Remove(cardToBeDestroyed);
            //Should we call some event to update GUI and stats of the personality(Which can be modified by attachments)    
        }

        //Add an attachment to the personality
        public void addAttachment(Attachment attachment)
        {
            //Since all attachment types are fate cards I have specified fate card as the argument type
            this.attachedCards.Add(attachment);
            attachment.attachedTo=this;
        }

        public bool canAttachAttachment(Attachment attachment)
        {
            //To be implimented
            return true;
        }

        //Destroy this personality including all attachments
        public override void destroyCard()
        {
            //if check to see if the personality is immune due to some other effect


            //You can't use the foreach if you are modifying the list that foreach is using
            for (int i = attachedCards.Count; i > 0; i--)
            {
                this.destroyCardInUnit(attachedCards[i - 1]);
            }

            //Will need to check if card is at battleground. Will add once code is updated.
            playerOwner.pDynastyDiscard.addCardToDiscard((DynastyCard)playerOwner.pHome.removeCardFromPlay(this));
            this.isDead = true;


        }

        //Return true if a follower is attached
        public bool hasFollowerAttachment()
        {

            bool returnValue = false;
            foreach (Follower fl in attachedCards)
            {
                returnValue = true;
                break;
            }

            return returnValue;
        }

        //Returns true if this personality has an attachment
        public bool hasAttachment()
        {
            bool returnValue = false;
            foreach (Attachment att in attachedCards)
            {
                returnValue = true;
                break;
            }

            return returnValue;

        }

        //Bows a specific attachemnt
        public void bowAttachedCard(Attachment target)
        {
            foreach (Attachment att in attachedCards)
            {
                if (att.Equals(target))
                {
                    target.IsBowed = true;
                }
            }
        }

        //Bow all attached cards
        public void bowAllAttachments()
        {
            foreach (Attachment att in attachedCards)
            {
                att.IsBowed = true;
            }
        }

        //Not implimented
        public override void handleEventsPhase(Gamestate gs)
        {

        }

        public int getUnitForce()
        {
            //just returning a random number for now until implimented
            Random rnd = new Random();
            return rnd.Next(0, 6);
        }

        #endregion

        #region Search methods
        //Returns a List of structs. Each struct has an attachment, an index of the attachment and what personality it is attached to.
        public List<Attachment> getAllAttachedCards()
        {
            List<Attachment> returnList = new List<Attachment>();
           
            foreach (Attachment aCard in this.attachedCards)
            {
                returnList.Add(aCard);              
            }

            return returnList;
            
        }
        
        //Returns a List of structs. Each struct has a follower attachment, an index of the attachment and what personality it is attached to.
        public List<Follower> getAllFollowers()
        {
            List<Follower> returnList = new List<Follower>();

            foreach (Follower att in attachedCards.OfType<Follower>())
            { 
                returnList.Add(att);
            }
            
            return returnList;
        }

        //Returns a List of structs. Each struct has an item attachment, an index of the attachment and what personality it is attached to.
        public List<Item> getAllItems()
        {
            List<Item> returnList = new List<Item>();

            foreach(Item att in attachedCards.OfType<Item>())
            {
                returnList.Add(att);
            }

            return returnList;
        }

        //Returns a List of structs. Each struct has an armor attachment, an index of the attachment and what personality it is attached to.
        public List<Armor> getAllArmor()
        {
            List<Armor> returnList = new List<Armor>();

            foreach(Armor att in attachedCards.OfType<Armor>())
            {
                returnList.Add(att);
            }
            return returnList;
        }

        //Returns a List of structs. Each struct has a weapon attachment, an index of the attachment and what personality it is attached to.
        public List<Weapon> getAllWeapons()
        {
            List<Weapon> returnList = new List<Weapon>();

           foreach(Weapon att in attachedCards.OfType<Weapon>())
           {
               returnList.Add(att);
           }
            return returnList;
        }

        //Returns a List of structs. Each struct has a spell attachment, an index of the attachment and what personality it is attached to.
        public List<Spell> getAllSpells()
        {
            List<Spell> returnList = new List<Spell>();

            foreach(Spell att in attachedCards.OfType<Spell>())
            {
                returnList.Add(att);
            }

            return returnList;
        }
        #endregion   
    }
}

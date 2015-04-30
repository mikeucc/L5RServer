using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5R.Gamestate
{
    
    public class PlayerHand
    {

        private List<FateCard> cardsInHand;

        public PlayerHand()
        {
            cardsInHand = new List<FateCard>();
        }

        //Will have to think about return types

        public FateCard discardRandomCard()
        {
            FateCard crdDiscarded;
            Random rnd = new Random();
            crdDiscarded = cardsInHand[rnd.Next(cardsInHand.Count - 1)];
            return this.discardCard(crdDiscarded);
           
        }

        public FateCard discardCard(FateCard cardToBeDiscarded)
        {
            cardsInHand.Remove(cardToBeDiscarded);
            return cardToBeDiscarded;
        }

        public void addCardToHand(FateCard crd)
        {
            cardsInHand.Add(crd);
        }

        public List<FateCard> getCardsInHand()
        {
            return cardsInHand;
        }

        #region search deck for card types
        public List<Armor> searchForArmors()
        {
            List<Armor> returnList = new List<Armor>();
            foreach (FateCard crd in cardsInHand)
            {
                if (crd is Armor)
                {
                    returnList.Add((Armor)crd);
                }
            }

            return returnList;
        }

        public List<Attachment> searchForAttachments()
        {
            List<Attachment> returnList = new List<Attachment>();
            foreach (FateCard crd in cardsInHand)
            {
                if (crd is Attachment)
                {
                    returnList.Add((Attachment)crd);
                }
            }

            return returnList;
        }

        public List<Follower> searchForFollower()
        {
            List<Follower> returnList = new List<Follower>();
            foreach (FateCard crd in cardsInHand)
            {
                if (crd is Follower)
                {
                    returnList.Add((Follower)crd);
                }
            }

            return returnList;
        }

        public List<Item> searchForItem()
        {
            List<Item> returnList = new List<Item>();
            foreach (FateCard crd in cardsInHand)
            {
                if (crd is Item)
                {
                    returnList.Add((Item)crd);
                }
            }

            return returnList;
        }

        public List<Spell> searchForSpell()
        {
            List<Spell> returnList = new List<Spell>();
            foreach (FateCard crd in cardsInHand)
            {
                if (crd is Spell)
                {
                    returnList.Add((Spell)crd);
                }
            }

            return returnList;
        }

        public List<Weapon> searchForWeapon()
        {
            List<Weapon> returnList = new List<Weapon>();
            foreach (FateCard crd in cardsInHand)
            {
                if (crd is Weapon)
                {
                    returnList.Add((Weapon)crd);
                }
            }

            return returnList;
        }

        public List<Ring> searchForRing()
        {
            List<Ring> returnList = new List<Ring>();
            foreach (FateCard crd in cardsInHand)
            {
                if (crd is Ring)
                {
                    returnList.Add((Ring)crd);
                }
            }

            return returnList;
        }

        public List<Kiho> searchForKiho()
        {
            List<Kiho> returnList = new List<Kiho>();
            foreach (FateCard crd in cardsInHand)
            {
                if (crd is Kiho)
                {
                    returnList.Add((Kiho)crd);
                }
            }

            return returnList;
        }

        public List<Strategy> searchForStrategy()
        {
            List<Strategy> returnList = new List<Strategy>();
            foreach (FateCard crd in cardsInHand)
            {
                if (crd is Strategy)
                {
                    returnList.Add((Strategy)crd);
                }
            }

            return returnList;
        }

        #endregion
    }
}

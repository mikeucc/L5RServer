using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5R.Gamestate
{
    public class PlayerFateDeck
    {
        private List<FateCard> fateDeck;
        private int topCardIndex;

        public PlayerFateDeck()
        {
            fateDeck = new List<FateCard>();
            topCardIndex = 0;
        }

        public void addFateCards(FateCard crd)
        {
            fateDeck.Add(crd);
        }

        public void addFateCards(List<FateCard> crds)
        {
            foreach (FateCard crd in crds)
            {
                fateDeck.Add(crd);
            }
        }


        public FateCard drawTopCard()
        {
            FateCard returnCard = this.fateDeck[topCardIndex];
            this.fateDeck.RemoveAt(topCardIndex);
            return returnCard;
        }


        public List<FateCard> lookAtTopXCards(int numCards)
        {
            if (numCards > fateDeck.Count)
            {
                return fateDeck.GetRange(topCardIndex, fateDeck.Count);
            }
            else
            {
                List<FateCard> cardsToBeLookedAt = this.fateDeck.GetRange(topCardIndex, numCards);
                return cardsToBeLookedAt;
            }
        }

        public FateCard getCardFromDeck(FateCard crd)
        {
            this.fateDeck.Remove(crd);
            return crd;
        }

        public void shuffleDeck()
        {
            int n = this.fateDeck.Count;

            while (n > 1)
            {
                n--;
                Random rnd = new Random();
                int k = rnd.Next(n + 1);
                FateCard rndCard = this.fateDeck[k];
                this.fateDeck[k] = this.fateDeck[n];
                this.fateDeck[n] = rndCard;
            }
        }

        #region search deck for card types
        public List<Armor> searchForArmors()
        {
            List<Armor> returnList=new List<Armor>();
            foreach(FateCard crd in fateDeck)
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
            foreach (FateCard crd in fateDeck)
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
            foreach (FateCard crd in fateDeck)
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
            foreach (FateCard crd in fateDeck)
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
            foreach (FateCard crd in fateDeck)
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
            foreach (FateCard crd in fateDeck)
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
            foreach (FateCard crd in fateDeck)
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
            foreach (FateCard crd in fateDeck)
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
            foreach (FateCard crd in fateDeck)
            {
                if (crd is Strategy)
                {
                    returnList.Add((Strategy)crd);
                }
            }

            return returnList;
        }

        public List<FateCard> searchForCards()
        {
            return fateDeck;
        }

        #endregion
    }
}

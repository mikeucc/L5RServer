using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5R.Gamestate
{
    public class PlayerFateDiscard
    {
        private List<FateCard> fateDiscard;

        public PlayerFateDiscard()
        {
            fateDiscard = new List<FateCard>();
        }


        public void addCardToDiscard(FateCard crd)
        {
            this.fateDiscard.Add(crd);
        }

        public FateCard lastCardDiscarded()
        {
            return fateDiscard.Last();
        }

        public int numberOfCardsDiscarded()
        {
            return fateDiscard.Count();
        }

        #region Return Methods for specific Card types in fate discard pile
        public List<FateCard> getDiscardedFateCards()
        {
            return fateDiscard;
        }

        public void removeCardFromDiscard(FateCard crd)
        {
            fateDiscard.Remove(crd);
        }

        public List<Spell> getDiscardedSpells()
        {
            List<Spell> returnList = new List<Spell>();
            foreach (FateCard crd in fateDiscard)
            {
                if (crd is Spell)
                {
                    returnList.Add((Spell)crd);
                }
            }

            return returnList;
        }

        public List<Attachment> getDiscardedAttachment()
        {
            List<Attachment> returnList = new List<Attachment>();
            foreach (FateCard crd in fateDiscard)
            {
                if (crd is Attachment)
                {
                    returnList.Add((Attachment)crd);
                }
            }

            return returnList;
        }

        public List<Armor> getDiscardedArmor()
        {
            List<Armor> returnList = new List<Armor>();
            foreach (FateCard crd in fateDiscard)
            {
                if (crd is Armor)
                {
                    returnList.Add((Armor)crd);
                }
            }

            return returnList;
        }

        public List<Follower> getDiscardedFollower()
        {
            List<Follower> returnList = new List<Follower>();
            foreach (FateCard crd in fateDiscard)
            {
                if (crd is Follower)
                {
                    returnList.Add((Follower)crd);
                }
            }

            return returnList;
        }

        public List<Item> getDiscardedItem()
        {
            List<Item> returnList = new List<Item>();
            foreach (FateCard crd in fateDiscard)
            {
                if (crd is Item)
                {
                    returnList.Add((Item)crd);
                }
            }

            return returnList;
        }

        public List<Weapon> getDiscardedWeapon()
        {
            List<Weapon> returnList = new List<Weapon>();
            foreach (FateCard crd in fateDiscard)
            {
                if (crd is Weapon)
                {
                    returnList.Add((Weapon)crd);
                }
            }

            return returnList;
        }

        public List<Ring> getDiscardedRing()
        {
            List<Ring> returnList = new List<Ring>();
            foreach (FateCard crd in fateDiscard)
            {
                if (crd is Ring)
                {
                    returnList.Add((Ring)crd);
                }
            }

            return returnList;
        }

        public List<Kiho> getDiscardedKiho()
        {
            List<Kiho> returnList = new List<Kiho>();
            foreach (FateCard crd in fateDiscard)
            {
                if (crd is Kiho)
                {
                    returnList.Add((Kiho)crd);
                }
            }

            return returnList;
        }

        public List<Strategy> getDiscardedStrategy()
        {
            List<Strategy> returnList = new List<Strategy>();
            foreach (FateCard crd in fateDiscard)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5R.Gamestate
{
    public class PlayerDynastyDeck
    {
        private List<DynastyCard> dynastyDeck;
        private int topCardIndex;

        public PlayerDynastyDeck()
        {
            dynastyDeck = new List<DynastyCard>();
            topCardIndex = 0;
        }

        public DynastyCard drawTopCard()
        {
            DynastyCard returnCard = this.dynastyDeck[topCardIndex];
            this.dynastyDeck.RemoveAt(topCardIndex);
            return returnCard;
        }


        public List<DynastyCard> lookAtTopXCards(int numCards)
        {
            if (numCards > dynastyDeck.Count)
            {
                return dynastyDeck.GetRange(topCardIndex, dynastyDeck.Count);
            }
            else
            {
                List<DynastyCard> cardsToBeLookedAt = this.dynastyDeck.GetRange(topCardIndex, numCards);
                return cardsToBeLookedAt;
            }
        }

        public DynastyCard getCardFromDeck(DynastyCard crd)
        {
            this.dynastyDeck.Remove(crd);
            return crd;
        }

        public void shuffleDeck()
        {
            
            Random ram = new Random();

            for (int a = 0; a < ram.Next(2, 10); a++)
            {
                Console.WriteLine("Deck shuffle number:" + a.ToString());
                int n = this.dynastyDeck.Count;
                while (n > 1)
                {
                    n--;
                    Random rnd = new Random();
                    int k = rnd.Next(n + 1);
                    DynastyCard rndCard = this.dynastyDeck[k];
                    this.dynastyDeck[k] = this.dynastyDeck[n];
                    this.dynastyDeck[n] = rndCard;
                }
            }
        }

        public void addCardsToDeck(DynastyCard crd)
        {
            Console.WriteLine("Adding:" + crd.name + " to deck");
            this.dynastyDeck.Add(crd);
        }

        public void addCardsToDeck(List<DynastyCard> crds)
        {
            foreach(DynastyCard crd in crds)
            {
                Console.WriteLine("Adding:" + crd.name + " to deck");
                dynastyDeck.Add(crd);
            }
        }

        #region search deck for card types
        public List<EventCard> searchForEvent()
        {
            List<EventCard> returnList = new List<EventCard>();
            foreach (DynastyCard crd in dynastyDeck)
            {
                if (crd is EventCard)
                {
                    returnList.Add((EventCard)crd);
                }
            }

            return returnList;
        }

        public List<Holding> searchForHolding()
        {
            List<Holding> returnList = new List<Holding>();
            foreach (DynastyCard crd in dynastyDeck)
            {
                if (crd is Holding)
                {
                    returnList.Add((Holding)crd);
                }
            }

            return returnList;
        }

        public List<Personality> searchForPersonality()
        {
            List<Personality> returnList = new List<Personality>();
            foreach (DynastyCard crd in dynastyDeck)
            {
                if (crd is Personality)
                {
                    returnList.Add((Personality)crd);
                }
            }

            return returnList;
        }

        public List<DynastyCard> searchForCards()
        {
            return dynastyDeck;
        }

        #endregion
    }
}

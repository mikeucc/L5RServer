using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5R.Gamestate
{
    public class PlayerDynastyDiscard
    {
        private List<DynastyCard> dynastyDiscard;

        public PlayerDynastyDiscard()
        {
            dynastyDiscard = new List<DynastyCard>();
        }

        public void addCardToDiscard(DynastyCard crd)
        {
            dynastyDiscard.Add(crd);
        }

        #region Getter methods for card types in dynasty discard pile

        public List<DynastyCard> getDiscardedDynastyCards()
        {
            List<DynastyCard> returnList = new List<DynastyCard>();
            foreach (DynastyCard crd in dynastyDiscard)
            {
                returnList.Add(crd);
            }

            return returnList;
        }

        public List<EventCard> getDiscardedEvents()
        {
            List<EventCard> returnList = new List<EventCard>();
            foreach (DynastyCard crd in dynastyDiscard)
            {
                if (crd is EventCard)
                {
                    returnList.Add((EventCard)crd);
                }
            }

            return returnList;
        }

        public List<Holding> getDiscardedHoldings()
        {
            List<Holding> returnList = new List<Holding>();
            foreach (DynastyCard crd in dynastyDiscard)
            {
                if (crd is Holding)
                {
                    returnList.Add((Holding)crd);
                }

            }

            return returnList;
        }

        public List<Personality> getDisCardedPersonality()
        {
            List<Personality> returnList = new List<Personality>();
            foreach (DynastyCard crd in dynastyDiscard)
            {
                if (crd is Personality)
                {
                    returnList.Add((Personality)crd);
                }
            }

            return returnList;
        }

        // Conditions can be dead, not dead , honourable etc
        public List<Personality> getDisCardedPersonality(ICondition cnd)
        {
            List<Personality> returnList = new List<Personality>();
            foreach (DynastyCard crd in dynastyDiscard)
            {
                if (crd is Personality)
                {
                    if(cnd.doesCardMeetCondition(crd))
                        returnList.Add((Personality)crd);
                }
            }

            return returnList;
        }


       

        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5R.Gamestate
{
    public class PlayerHome
    {
        #region Variables
        private List<Personality> unitsInPlay;
        private List<Holding> holdingsInPlay;
        private List<Strategy> strategiesInPlay;
        private List<Ring> ringsInPlay;
        private List<EventCard> eventsInPlay;

        public PlayerHome()
        {
            unitsInPlay = new List<Personality>();
            holdingsInPlay = new List<Holding>();
            strategiesInPlay = new List<Strategy>();
            ringsInPlay = new List<Ring>();
            eventsInPlay = new List<EventCard>();
        }
        #endregion

        #region Performed Actions
        public void putCardIntoPlay(Card crd)
        {
            if(crd is Personality)
                unitsInPlay.Add((Personality)crd);
            if (crd is Holding) 
                holdingsInPlay.Add((Holding)crd);
            if (crd is Strategy)
                strategiesInPlay.Add((Strategy)crd);
            if (crd is Ring)
                ringsInPlay.Add((Ring)crd);
            if (crd is EventCard)
                eventsInPlay.Add((EventCard)crd);
        }

        public Card removeCardFromPlay(Card crd)
        {
            if (crd is Personality)
                unitsInPlay.Remove((Personality)crd);
            if (crd is Holding)
                holdingsInPlay.Remove((Holding)crd);
            if (crd is Strategy)
                strategiesInPlay.Remove((Strategy)crd);
            if (crd is Ring)
                ringsInPlay.Remove((Ring)crd);
            if (crd is EventCard)
                eventsInPlay.Remove((EventCard)crd);
            
            return crd;
        }

        #endregion

        #region Search for cards

        public List<Personality> searchForPersonalities()
        {
            return unitsInPlay;
        }

        public List<Personality> searchForPersonalities(ICondition cnd)
        {
            List<Personality> returnList=new List<Personality>();

            foreach(Personality per in unitsInPlay)
            {
                if(cnd.doesCardMeetCondition(per))
                    returnList.Add(per);
            }

            return returnList;
        }
        

        public List<Holding> searchForHolding()
        {
            return holdingsInPlay;
        }

        public List<Holding> searchForHolding(ICondition cnd)
        {
            List<Holding> returnList = new List<Holding>();
            foreach (Holding hld in holdingsInPlay)
            {
                if (cnd.doesCardMeetCondition(hld))
                    returnList.Add(hld);
            }

            return returnList;
        }

        public List<EventCard> searchForEvents()
        {
            return eventsInPlay;
        }

        public List<Strategy> searchForStrategies()
        {
            return strategiesInPlay;
        }

        
        public List<Ring> searchForRings()
        {
            return ringsInPlay;
        }

        public List<Ring> searchForRings(ICondition cnd)
        {
            List<Ring> returnList = new List<Ring>();

            foreach (Ring rng in ringsInPlay)
            {
                if (cnd.doesCardMeetCondition(rng))
                    returnList.Add(rng);
            }

            return returnList;
        }

        
        public List<Attachment> searchForAttachments()
        {
            List<Attachment> returnList = new List<Attachment>();

            foreach(Personality per in unitsInPlay)
            {
                foreach(Attachment att in per.getAllAttachedCards())
                {
                    returnList.Add(att);
                }
            }

            return returnList;
        }

        public List<Attachment> searchForAttachments(ICondition cnd)
        {
            List<Attachment> returnList = new List<Attachment>();

            foreach (Personality per in unitsInPlay)
            {
                foreach (Attachment att in per.getAllAttachedCards())
                {
                    if(cnd.doesCardMeetCondition(att))
                        returnList.Add(att);
                }
            }

            return returnList;
        }



        public List<Armor> searchForArmor()
        {
            List<Armor> returnList = new List<Armor>();

            foreach (Personality per in unitsInPlay)
            {
                foreach (Armor att in per.getAllArmor())
                {
                    returnList.Add(att);
                }
            }

            return returnList;
        }

        public List<Armor> searchForArmor(ICondition cnd)
        {
            List<Armor> returnList = new List<Armor>();

            foreach (Personality per in unitsInPlay)
            {
                foreach (Armor att in per.getAllArmor())
                {
                    if(cnd.doesCardMeetCondition(att))
                        returnList.Add(att);
                }
            }

            return returnList;
        }

        public List<Follower> searchForFollower()
        {
            List<Follower> returnList = new List<Follower>();

            foreach (Personality per in unitsInPlay)
            {
                foreach (Follower att in per.getAllFollowers())
                {
                    returnList.Add(att);
                }
            }

            return returnList;
        }

        public List<Follower> searchForFollower(ICondition cnd)
        {
            List<Follower> returnList = new List<Follower>();

            foreach (Personality per in unitsInPlay)
            {
                foreach (Follower att in per.getAllFollowers())
                {
                    if(cnd.doesCardMeetCondition(att))
                        returnList.Add(att);
                }
            }

            return returnList;
        }

        public List<Item> searchForItem()
        {
            List<Item> returnList = new List<Item>();

            foreach (Personality per in unitsInPlay)
            {
                foreach (Item att in per.getAllItems())
                {
                    returnList.Add(att);
                }
            }

            return returnList;
        }

        public List<Item> searchForItem(ICondition cnd)
        {
            List<Item> returnList = new List<Item>();

            foreach (Personality per in unitsInPlay)
            {
                foreach (Item att in per.getAllItems())
                {
                    if(cnd.doesCardMeetCondition(att))
                        returnList.Add(att);
                }
            }

            return returnList;
        }

        public List<Spell> searchForSpells()
        {
            List<Spell> returnList = new List<Spell>();

            foreach (Personality per in unitsInPlay)
            {
                foreach (Spell att in per.getAllSpells())
                {
                    returnList.Add(att);
                }
            }

            return returnList;
        }

        public List<Spell> searchForSpells(ICondition cnd)
        {
            List<Spell> returnList = new List<Spell>();

            foreach (Personality per in unitsInPlay)
            {
                foreach (Spell att in per.getAllSpells())
                {
                    if(cnd.doesCardMeetCondition(att))
                        returnList.Add(att);
                }
            }

            return returnList;
        }

        public List<Weapon> searchForWeapons()
        {
            List<Weapon> returnList = new List<Weapon>();

            foreach(Personality per in unitsInPlay)
            {
                foreach(Weapon att in per.getAllWeapons())
                {
                    returnList.Add(att);
                }
            }

            return returnList;
        }

        public List<Weapon> searchForWeapons(ICondition cnd)
        {
            List<Weapon> returnList = new List<Weapon>();

            foreach (Personality per in unitsInPlay)
            {
                foreach (Weapon att in per.getAllWeapons())
                {
                    if(cnd.doesCardMeetCondition(att))
                        returnList.Add(att);
                }
            }

            return returnList;
        }

        #endregion
    }
}

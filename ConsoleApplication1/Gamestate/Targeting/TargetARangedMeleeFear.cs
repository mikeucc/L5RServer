using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class TargetARangedMeleeFear:ITarget
    {
        public override List<Card> returnTargetList(Gamestate gs, ICondition cond)
        {
            //List to be returned
            List<Card> returnList = new List<Card>();
           
               //Are there at least 1 opposing units
            if (gs.currentBattlefield.opposingCards(gs.performingPlayer).Count > 0)
                {
                    //Add targets to list
                    foreach (Personality per in gs.currentBattlefield.opposingCards(gs.performingPlayer))
                    {

                        //Personality has no followers so is legal target
                        if (per.getAllFollowers().Count == 0)
                        {
                            if (cond.doesCardMeetCondition(per))
                            {
                                returnList.Add(per);
                            }
                        }
                        //otherwise get its list of followers as legal targets instead
                        else
                        {
                            foreach (Follower folStruct in per.getAllFollowers())
                            {
                                if (cond.doesCardMeetCondition(folStruct))
                                {
                                    returnList.Add(folStruct);
                                }
                            }
                        }
                    }
                }
            
           
            
            return returnList;
        }
    }
}

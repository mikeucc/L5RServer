using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class Province
    {
        
        // This should always be 1, aka 1 card per province, but there might be a situation where this is not the case
        public DynastyCard purchasableCard { get; set; }

        //Fortifications attached to the province
        public List<DynastyCard> attachedCards { get; set; }

        //Constructor will set this to the strongholds value, but can be modified by other cards
        public int currentProvinceStrength { get; set; }

        public Player owner { get; private set; }

        public Province(Player owns)
        {

            attachedCards = new List<DynastyCard>();
            this.owner = owns;
            this.currentProvinceStrength = owner.stronghold.baseStrength;
        }


        //triggers after battle resolution. Conditions will be checked in battlefield object
        public void destroyProvince()
        {
            owner.playerProvinces.Remove(this);
        }

        public void refillProvince()
        {
            try
            {
                this.purchasableCard = owner.pDynastyDeck.drawTopCard();
                
            }
            catch
            {
                Console.WriteLine("Out of deck");
            }

        }
    }
}

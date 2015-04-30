using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class Home
    {
        //Personalitys and holdings at home
        public List<DynastyCard> dynastyCardsAtHome { get; set; }

        //Kata's and Rings in plau
        public List<FateCard> fateCardsAtHome { get; set; }
    }
}

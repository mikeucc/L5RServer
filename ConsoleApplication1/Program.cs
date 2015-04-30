using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5R.Gamestate
{
    class Program
    {
        public static Gamestate gs;
        static void Main(string[] args)
        {
            Player p1 = new Player();
            Player p2 = new Player();

            gs = new Gamestate(p1, p2);

            p1.gs = gs;
            p2.gs = gs;

            List<DynastyCard> ddeck = new List<DynastyCard>();

            ddeck.Add(new IVE_071());
            ddeck.Add(new IVE_071());
            ddeck.Add(new IVE_071());

            ddeck.Add(new IVE_072());
            ddeck.Add(new IVE_072());
            ddeck.Add(new IVE_072());

            ddeck.Add(new IVE_073());
            ddeck.Add(new IVE_073());
            ddeck.Add(new IVE_073());

            ddeck.Add(new IVE_074());
            ddeck.Add(new IVE_074());
            ddeck.Add(new IVE_074());

            ddeck.Add(new IVE_008());
            ddeck.Add(new IVE_008());
            ddeck.Add(new IVE_008());

            ddeck.Add(new ALITS_004());
            ddeck.Add(new ALITS_004());
            ddeck.Add(new ALITS_004());

            ddeck.Add(new ALITS_027());
            ddeck.Add(new ALITS_027());
            ddeck.Add(new ALITS_027());

            ddeck.Add(new AM_010());
            ddeck.Add(new AM_010());
            ddeck.Add(new AM_010());

            ddeck.Add(new AM_012());
            ddeck.Add(new AM_012());
            ddeck.Add(new AM_012());
            
            ddeck.Add(new AM_022());
            ddeck.Add(new AM_022());
            ddeck.Add(new AM_022());

            ddeck.Add(new AM_027());
            ddeck.Add(new AM_027());
            ddeck.Add(new AM_027());

            ddeck.Add(new TCS_008());
            ddeck.Add(new TCS_008());
            ddeck.Add(new TCS_008());

            ddeck.Add(new TCS_031());
            ddeck.Add(new TCS_031());
            ddeck.Add(new TCS_031());

            ddeck.Add(new Promo_159());
            ddeck.Add(new Promo_159());
            ddeck.Add(new Promo_159());

            Stronghold p1sh = new IVE_365();
            Stronghold p2sh = new IVE_366();

            p1sh.createCard(p1);
            p2sh.createCard(p2);



            List<DynastyCard> ddeck2 = new List<DynastyCard>();

            ddeck2.Add(new IVE_084());
            ddeck2.Add(new IVE_084());
            ddeck2.Add(new IVE_084());

            ddeck2.Add(new IVE_085());
            ddeck2.Add(new IVE_085());
            ddeck2.Add(new IVE_085());

            ddeck2.Add(new IVE_089());
            ddeck2.Add(new IVE_089());
            ddeck2.Add(new IVE_089());

            ddeck2.Add(new IVE_008());
            ddeck2.Add(new IVE_008());
            ddeck2.Add(new IVE_008());


            List<FateCard> fdeck = new List<FateCard>();
            List<FateCard> fdeck2 = new List<FateCard>();

            fdeck.Add(new IVE_319());
            fdeck.Add(new IVE_319());
            fdeck.Add(new IVE_319());

            fdeck2.Add(new IVE_319());
            fdeck2.Add(new IVE_319());
            fdeck2.Add(new IVE_319());

            p1sh.createCard(p1);
            p2sh.createCard(p2);
            p1.setPlayerAbilities();
            p2.setPlayerAbilities();

            foreach(FateCard fc in fdeck)
            {
                fc.createCard(p1);
            }

            foreach (FateCard fc in fdeck2)
            {
                fc.createCard(p2);
            }

            foreach (DynastyCard dc in ddeck)
            {
                dc.createCard(p1);
            }
            foreach (DynastyCard dc in ddeck2)
            {
                dc.createCard(p2);
            }

            p1.setPlayerDeck(fdeck, ddeck, p1sh);
            p2.setPlayerDeck(fdeck2, ddeck2, p2sh);


            

            p1.fillProvinces();
            p2.fillProvinces();
            

           

            gs.updateState();
            
        }
    }
}

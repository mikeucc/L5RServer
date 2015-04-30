﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class EGainImperialFavour:IEffect
    {
        public override bool applyEffects(Gamestate gs)
        {
            gs.performingPlayer.hasImperialFavour = true;
            return true;
        }

        public override bool canBePlayed(Gamestate gs)
        {
            try
            {
                foreach (Personality per in gs.performingPlayer.cardsInPlay)
                {
                    if (per.isHonourable && per.personalHonor > 0 && gs.performingPlayer.familyHonour > gs.performingPlayer.opposingPlayer.familyHonour)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                //Personalities not in play
            }

            return false;
            
        }
    }
}

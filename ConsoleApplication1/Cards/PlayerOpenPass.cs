﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class PlayerOpenPass:PlayerCard
    {
        public override void createCard(Player owner)
        {
            this.playerOwner=owner;
            this.name = "Player Open Pass";
            
            
            ActionOpenRepeatable tempAction=new ActionOpenRepeatable();
            tempAction.gs = playerOwner.gs;
            tempAction.displayActionText = "Open: Pass";

            EPass tempEffect = new EPass();


            tempEffect.effectOwner = tempAction;
            tempAction.actionsEffects.Add(tempEffect);
            tempAction.actionOwner=this;

            this.cardAbilities.Add(tempAction);
           

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    class ActionBattleChooseEffect:IAction
    {
        public List<string> choiceText { get; set; }

        public List<IEffect> choiceEffects { get; set; }
        

        public Player playerToMakeChoice { get; set; }

        public int numberOfChoices { get; set; }


        public List<IEffect> makeChoice()
        {
            return this.actionOwner.playerOwner.gs.pickEffects(choiceEffects, numberOfChoices, playerToMakeChoice);
        }
    }
}

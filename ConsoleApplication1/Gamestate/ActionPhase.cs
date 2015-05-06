using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class ActionPhase
    {
        Gamestate gs;
        public ActionPhase(Gamestate gs)
        {
            this.gs = gs;


        }


        public void startActionPhase()
        {
            //Set both players status to not have passed
            gs.activePlayer.hasPassed = false;
            gs.inactivePlayer.hasPassed = false;

            foreach (Card playerCard in gs.activePlayer.cardsInPlay)
            {
                //playerCard.IsBowed = false;
                playerCard.straighten();
            }


            // for each province card
            foreach (Province pv in gs.activePlayer.playerProvinces)
            {
                //Flip facedown cards faceup
                pv.purchasableCard.turnFaceUp();
                Console.WriteLine("Card in province is: " + pv.purchasableCard.name);

            }
        }

        public void setActionListInGameState()
        {
            gs.performingPlayer.setLegalCardsInPlay();
            gs.performingPlayer.setLegalCardsInHand();
            gs.performingPlayer.setLegalCardsFromUnits();
            gs.performingPlayer.setLegalCardfFromPlayerAbilities();    
            gs.createActiveActionList();
         

        }

        public void setInterruptListGameState()
        {
            gs.performingPlayer.setLegalInterruptFromPlayerAbilities();
            gs.performingPlayer.setLegalInterruptFromUnits();
            gs.performingPlayer.setLegalInterruptInHand();
            gs.performingPlayer.setLegalInterruptInPlay();
            gs.createActiveActionList();
            
        }

        
        
        public void performActionPhase()
        {
            //if both players have passed move onto next phase
            if (gs.activePlayer.hasPassed && gs.inactivePlayer.hasPassed)
            {
                gs.isActionPhase = false;
                gs.isBattlePhase = false;
                gs.isDynastyPhase = true;
                gs.performingPlayer = gs.activePlayer;
                return;
            }
            
            //Generate list of valid actions to be sent to the client
            if (gs.currentActionBeingPlayed == null)
            {
                this.setActionListInGameState();
                Console.WriteLine("Perform Action phase:Setting action List");
                gs.pickAction();
                return;
            }

            //If both players have passed their interrupts, resolve the action
            if (gs.activePlayer.InterruptHasPassed && gs.inactivePlayer.InterruptHasPassed)
            {
                gs.currentActionBeingPlayed.resolveEffects();
                gs.player1.InterruptHasPassed = false;
                gs.player2.InterruptHasPassed = false;
                gs.currentActionBeingPlayed.actionPerformed = true;
                gs.currentActionBeingPlayed = null;
                return;
            }
            else
            {
                this.setInterruptListGameState();
                gs.pickAction();
            }
        }
    }
}

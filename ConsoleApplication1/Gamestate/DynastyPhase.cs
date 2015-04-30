using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class DynastyPhase
    {
        public Gamestate gs;

        public DynastyPhase(Gamestate gs)
        {
            this.gs = gs;
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

        public void performDynastyPhase()
        {
            if (gs.activePlayer.hasPassed)
            {
                //end of turn
                try
                {
                    gs.activePlayer.pHand.addCardToHand(gs.activePlayer.pFateDeck.drawTopCard());

                    if (gs.activePlayer.pHand.getCardsInHand().Count > gs.activePlayer.maxHandSize)
                    {
                        //Player Must discard down to 8 cards
                    }
                }
                catch
                {
                    Console.WriteLine("Out of fate deck");
                }


                gs.swapActivePlayer();
                gs.isDynastyPhase = false;
                gs.isActionPhase = true;
                gs.actionPhase = null;
                Console.WriteLine(gs.activePlayer.aLabel);
                return;
            }

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


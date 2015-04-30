using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace L5R.Gamestate
{
    public class AttackPhase
    {
        public Player attackingPlayer;
        public Player defendingPlayer;
        public Gamestate gamestate;
        public List<Battlefield> unresolvedbattlefields;
        public List<Battlefield> resolvedBattleFields;
        public Battlefield currentBattleField;

        public AttackPhase(Player attackingPlayer, Player defendingPlayer, Gamestate gamestate)
        {
            this.attackingPlayer = attackingPlayer;
            this.defendingPlayer = defendingPlayer;
            this.gamestate = gamestate;
            this.unresolvedbattlefields=new List<Battlefield>();
            gamestate.unresolvedBattlefield = this.unresolvedbattlefields;
            this.resolvedBattleFields = new List<Battlefield>();
            AssignUnitsToBattlefields();

        }

        public void AssignUnitsToBattlefields()
        {
            foreach (Province pv in defendingPlayer.playerProvinces)
            {
                unresolvedbattlefields.Add(new Battlefield(pickAttackingUnits(),attackingPlayer,pickDefendingUnits(),defendingPlayer,pv));
            }
        }

        public List<Personality> pickAttackingUnits()
        {
            List<Personality> attUnits = new List<Personality>();



            return attUnits;
        }

        public List<Personality> pickDefendingUnits()
        {
            List<Personality> defUnits = new List<Personality>();

            return defUnits;
        }


        public void pickBattleFieldToResolve()
        {
            //resolve each battlefield. attacker chooses which one to resolve
            while (unresolvedbattlefields.Count > 0)
            {
                //Attacking player chooses a BF
                currentBattleField = attackerChosesBF();
                attackingPlayer.currentBattlefield = currentBattleField;
                defendingPlayer.currentBattlefield = currentBattleField;
                currentBattleField.engagePhase();
                currentBattleField.battlePhase();
                currentBattleField.resolutionPhase();
                unresolvedbattlefields.Remove(currentBattleField);
            }

        }




        public Battlefield attackerChosesBF()
        {
            //Not implimented
            return currentBattleField;
        }

        public List<Battlefield> adjacentBattleField(Battlefield currentBattlefield)
        {
            List<Battlefield> returnValue=new List<Battlefield>();

            int bfPosition= this.unresolvedbattlefields.IndexOf(currentBattlefield);

            try
            {
                returnValue.Add(this.unresolvedbattlefields[bfPosition - 1]);
            }
            catch
            {
                //no such province exists
            }

            try
            {
                returnValue.Add(this.unresolvedbattlefields[bfPosition + 1]);
            }
            catch
            {
                // no such province exists
            }
            return returnValue;
        }
    }
}

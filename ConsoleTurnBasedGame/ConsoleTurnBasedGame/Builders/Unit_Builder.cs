using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleTurnBasedGame
{
    static class Unit_Builder
    {
        static int id_pool = 0; //Unique id for every unit

        //Read external data (file/database)
        //Create unit
        //Create actions/moves/other misc. stuff (weapons, passives, etc.)
        //Attach extras to unit
        //Return unit
        public static Unit loadUnit(string input)
        {
            return null;
        }

        public static Unit createTestUnit()
        {
            Unit output = new Unit();
            Action baseAttack = new Action();
            Move baseMove = new Move();

            output.addAction(baseAttack);
            output.addMove(baseMove);

            output.id = id_pool;
            id_pool++;

            return output;
        }
    }
}

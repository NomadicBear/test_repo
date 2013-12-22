using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTurnBasedGame
{
    //TODO: Need to rethink how Move works - right now its just duplicating stats from Unit
    //Also if using stamina/ap system, Move will need to copy those since they update every turn
    class Move
    {
        public Unit target;
        public Selection_Grid selection_grid;
        public int horizontal_movement_range;
        public int vertical_movement_range;
        //More stats like 'move type' to represent sprinting, walking, crawling, flying, etc.?
    }
}

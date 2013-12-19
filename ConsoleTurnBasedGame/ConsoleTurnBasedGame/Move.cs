using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTurnBasedGame
{
    class Move
    {
        public Unit target;
        public Selection_Grid selection_grid;
        public int horizontal_movement_range;
        public int vertical_movement_range;
    }
}

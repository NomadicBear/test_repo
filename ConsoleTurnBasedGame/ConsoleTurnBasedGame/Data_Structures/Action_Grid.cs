using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTurnBasedGame
{
    //TODO: Decide if there's anything else I want to add to this class that a List can't do
    class Action_Grid
    {
        public List<Action_Tile> grid; //TODO: Could be an array, decide later

        public Action_Grid()
        {
            
        }
    }

    class Action_Tile
    {
        Tile reference_tile;
        int distance_from_origin;
        int travel_cost;    //distance and cost may not end up being the same, hence the need for this
        Tile[] shortest_path;    //every key tile (where a change in direction occurs or move skill is used) on the way to this
    }
}

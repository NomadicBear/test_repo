using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTurnBasedGame
{
    class Move_Grid
    {
        public List<Selection_Data> tile_selection_list; //TODO: Could be an array, decide later
        public Dictionary<Tile, Selection_Data> selection_grid;    //Tile_id, Move_Tile

        public Move_Grid()
        {
            tile_selection_list = new List<Selection_Data>();
        }

        public void addTile(Tile new_tile, int new_distance, int new_cost, List<Tile> new_path)
        {
            if (!containsTile(new_tile))
            {
                selection_grid.Add(new_tile, new Selection_Data(new_distance, new_cost, new_path));
            }
        }

        public void replaceTile(Tile new_tile, int new_distance, int new_cost, List<Tile> new_path)
        {
            if (!containsTile(new_tile))
            {
                selection_grid[new_tile] = new Selection_Data(new_distance, new_cost, new_path);
            }
        }

        public bool containsTile(Tile input)
        {
            return selection_grid.ContainsKey(input);
        }

        //Returns 0 if new cost = old cost, 1 if new cost is larger, -1 if new cost is smaller or doesn't exist
        public int comparePath(Tile new_tile, int new_cost)
        {
            Selection_Data selection_data;
            if (selection_grid.TryGetValue(new_tile, out selection_data))
            {
                if (selection_data.travel_cost > new_cost)
                {
                    return -1;
                }
                else if (selection_data.travel_cost == new_cost)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }

            return -1;
        }

        private class Selection_Data
        {
            public int distance_from_origin;
            public int travel_cost;    //distance and cost may not end up being the same, hence the need for this
            public List<Tile> shortest_path;    //every key tile (where a change in direction occurs or move skill is used) on the way to this

            public Selection_Data()
            {
                distance_from_origin = -1;
                travel_cost = -1;
                shortest_path = null;
            }

            public Selection_Data(int newDistance, int newTravel_cost, List<Tile> newShortest_path)
            {
                distance_from_origin = newDistance;
                travel_cost = newTravel_cost;
                shortest_path = new List<Tile>(newShortest_path);
            }
        }
    }

    
}

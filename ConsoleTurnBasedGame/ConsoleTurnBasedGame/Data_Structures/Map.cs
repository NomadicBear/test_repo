using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleTurnBasedGame
{
    class Map
    {
        //TODO: Discover possible alternatives to 3d arrays
        //Possibly a 2d array of Dictionary<int, Tile> where int is the y value?
        //A simply better way would be to use a Tile[], and write methods to insert/retrieve via transforms
        public Tile[][][] tile_map; //NOTE: Array is ordered by y, z, x
        public int size_x, size_y, size_z;
        public int tile_count;

        public Map()
        {
            tile_map = null;
            size_x = 0;
            size_y = 0;
            size_z = 0;
            tile_count = 0;
        }

        public Unit returnUnit(int x, int y, int z)
        {
            return returnTile(x, y, z).occupant;
        }

        public Tile returnTile(int x, int y, int z)
        {
            return tile_map[y][z][x];
        }

        //TODO: Figure out if this is useful.
        //Its either this or have each tile have a ref to every neighbouring tile above/below/around it
        //Alternatively, order the 3d array to be [x][z][y] - returning [x][z] will give us the [y] stack
        public Tile[] returnYStack(int x, int z)
        {
            return null;
        }

        //TODO: What is a 'neighbour'? Figure out the cases the satisfy the condition of 'neighbour' and implement accordingly
        //There's a case for tiles to be adjacent to each other but completely unreachable to each other
        //Just because of height differences, possible walls, etc.
        //TODO: Consider placing this method inside Tile and storing neighour data there
        //THIS IS HIGH PRIORITY
        //NOTE: For now, this assumes that there is no height difference between tiles
        public Tile[] getNeighbours(Tile inputTile)
        {
            List<Tile> output = new List<Tile>();
            if (inputTile.location_x + 1 >= size_x)
            {
                output.Add(returnTile(inputTile.location_x + 1, inputTile.location_y, inputTile.location_z));
            }
            if (inputTile.location_x - 1 < 0)
            {
                output.Add(returnTile(inputTile.location_x - 1, inputTile.location_y, inputTile.location_z));
            }
            if (inputTile.location_z + 1 >= size_z)
            {
                output.Add(returnTile(inputTile.location_x, inputTile.location_y, inputTile.location_z + 1));
            }
            if (inputTile.location_x - 1 < 0)
            {
                output.Add(returnTile(inputTile.location_x, inputTile.location_y, inputTile.location_z - 1));
            }

            return output.ToArray();
        }
    }
}

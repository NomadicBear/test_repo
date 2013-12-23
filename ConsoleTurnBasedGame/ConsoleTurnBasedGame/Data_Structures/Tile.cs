using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTurnBasedGame
{
    class Tile
    {
        public Unit occupant;
        public int location_x, location_y, location_z;
        public Terrain terrain;

        public int tile_id; //TODO: Determine how useful this is.. I can imagine it being used in building selection grids, but we'll see
        

        public Tile(int x, int y, int z, Terrain newTerrain)
        {
            occupant = null;
            location_x = x;
            location_y = y;
            location_z = z;

            terrain = newTerrain;

            tile_id = -1;
        }

        public Tile(int x, int y, int z)
        {
            occupant = null;
            location_x = x;
            location_y = y;
            location_z = z;

            terrain = Terrain.GRASSLAND;

            tile_id = -1;
        }

    }

    enum Terrain
    {
        GRASSLAND,
        PLAIN,
        WETLAND,
        SHALLOW_WATER,
        DEEP_WATER,
    }
}

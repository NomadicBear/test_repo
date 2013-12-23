﻿using System;
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

        public Tile[] returnXZStack(int x, int z)
        {
            return null;
        }
    }
}

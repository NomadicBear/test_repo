using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTurnBasedGame
{
    class Overlay
    {
        public Overlay_Tile[] overlay_map { get; private set; }
        public int max_x { get; private set; }
        public int max_z { get; private set; }
        public int flat_tile_count { get; private set; }
        public int dim_tile_count { get; private set; }

        public Overlay(Overlay_Tile[] new_overlay_map, int new_x, int new_z)
        {
            overlay_map = new_overlay_map;
            max_x = new_x;
            max_z = new_z;
            flat_tile_count = overlay_map.Length;

            foreach (Overlay_Tile tile in overlay_map)
            {
                if (tile.y_value == -1)
                {
                    dim_tile_count = -1;
                    break;
                }
                else
                {
                    switch (tile.y_type)
                    {
                        case Y_Direction.BOTH:
                            dim_tile_count += tile.y_value * 2;
                            break;
                        case Y_Direction.DOWN:
                            dim_tile_count += tile.y_value;
                            break;
                        case Y_Direction.UP:
                            dim_tile_count += tile.y_value;
                            break;
                    }
                }
            }
        }
    }

    class Overlay_Tile
    {
        public int relative_x { get; private set; }
        public int relative_z { get; private set; }
        public int y_value { get; private set; }
        public Y_Direction y_type { get; private set; }

        public Overlay_Tile(int new_x, int new_z, int new_y_growth, Y_Direction new_y_type)
        {
            relative_x = new_x;
            relative_z = new_z;
            y_value = new_y_growth;
            y_type = new_y_type;
        }
    }

    enum Y_Direction
    {
        NONE,
        UP,
        DOWN,
        BOTH
    }
}

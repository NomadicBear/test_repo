using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTurnBasedGame.Builders
{
    static class Selection_Grid_Builder
    {
        //Needs: overlay from Action, location tile from Unit and game Map
        //Takes location tile from unit and overlay from Action, searches tiles on Map that falls within overlay using location as origin and adds it to a list
        //returns list of tiles as output
        public static Selection_Grid createGrid(Action inputAction, Map inputMap, Tile origin)
        {
            int current_x_value, current_z_value, current_y_value;
            Tile currentTile = null;
            Selection_Grid output = new Selection_Grid();

            foreach (Overlay_Tile tile in inputAction.overlay.overlay_map)
            {
                current_x_value = origin.location_x + tile.relative_x;
                current_z_value = origin.location_z + tile.relative_z;

                //NOTE: y value does not include the origin layer
                //If y value is 10 + UP, layers 0 to 10 would be affected
                //If y value is 10 + BOTH, layers -10 to 10 would be affect
                if (tile.y_type == Y_Direction.UP)
                {
                    for (int i = 0; i <= tile.y_value; i++)
                    {
                        current_y_value = origin.location_y + i;
                        currentTile = inputMap.returnTile(current_x_value, current_y_value, current_z_value);
                        if (currentTile != null)
                        {
                            output.grid.Add(currentTile);
                        }
                    }
                }
                else if (tile.y_type == Y_Direction.DOWN)
                {
                    for (int i = tile.y_value * -1; i <= 0; i++)
                    {
                        current_y_value = origin.location_y + i;
                        currentTile = inputMap.returnTile(current_x_value, current_y_value, current_z_value);
                        if (currentTile != null)
                        {
                            output.grid.Add(currentTile);
                        }
                    }
                }
                else if (tile.y_type == Y_Direction.BOTH)
                {
                    for (int i = tile.y_value * -1; i <= tile.y_value; i++)
                    {
                        current_y_value = origin.location_y + i;
                        currentTile = inputMap.returnTile(current_x_value, current_y_value, current_z_value);
                        if (currentTile != null)
                        {
                            output.grid.Add(currentTile);
                        }
                    }
                }
                else   //for Y_Direction.NONE
                {
                    current_y_value = origin.location_y;
                    currentTile = inputMap.returnTile(current_x_value, current_y_value, current_z_value);
                    if (currentTile != null)
                    {
                        output.grid.Add(currentTile);
                    }
                }
            }
            
            return output;
        }

        //Needs: move data, unit location (and probably other unit data in the future?)
        //Takes location tile from unit, then..
        //DFS or BFS on the Map starting from origin until out of moves, tossing tiles traveled into a list
        //mark them with a hashset<int/string> where int is the tile_id or use a string made of x/y/z appended
        //return list of tiles as output
        //TODO: Maybe add in more data to Selection Grid? Edge value would be useful if there are other move options than 'walk 1 step'
        //TODO: Perhaps include more data to Map? Right now there are no edge data, just neighbour data from logical inference which isn't the same thing
        //If we add in edge data, we can do something like 'Walk -> Tile[]', 'Wall-run -> Tile[]' which just provides a list of tiles a unit can access with certain Moves
        public static Selection_Grid createGrid(Move inputMove, Map inputMap, Tile origin)
        {
            HashSet<String> marker = new HashSet<String>();
            
        }
    }
}

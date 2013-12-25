using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTurnBasedGame.Builders
{
    static class Action_Grid_Builder
    {
        //Needs: overlay from Action, location tile from Unit and game Map
        //Takes location tile from unit and overlay from Action, searches tiles on Map that falls within overlay using location as origin and adds it to a list
        //returns list of tiles as output
        public static Action_Grid createGrid(Action inputAction, Map inputMap, Tile origin)
        {
            int current_x_value, current_z_value, current_y_value;
            Tile currentTile = null;
            Action_Grid output = new Action_Grid();

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

    }
}

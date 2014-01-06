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
        public List<Tile> tile_selection_list; //TODO: Could be an array, decide later
        public List<Unit> unit_selection_list;

        public Action_Grid()
        {
            tile_selection_list = new List<Tile>();
            unit_selection_list = new List<Unit>();
        }

        public void addTile(Tile newTile)
        {
            tile_selection_list.Add(newTile);

            if (newTile.occupant != null)
            {
                unit_selection_list.Add(newTile.occupant);
            }
        }
    }

}

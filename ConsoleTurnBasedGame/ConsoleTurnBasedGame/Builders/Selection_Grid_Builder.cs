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
            return null;
        }

        //Needs: move data, unit location (and probably other unit data in the future?)
        //Takes location tile from unit, then..
        //DFS or BFS on the Map starting from origin until out of moves, tossing tiles traveled into a list
        //return list of tiles as output
        public static Selection_Grid createGrid(Move inputMove, Map inputMap, Tile origin)
        {
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTurnBasedGame.Builders
{
    static class Move_Grid_Builder
    {

        //Needs: move data, unit location (and probably other unit data in the future?)
        //Takes location tile from unit, then..
        //DFS or BFS on the Map starting from origin until out of moves, tossing tiles traveled into a list
        //mark them with a hashset<int/string> where int is the tile_id or use a string made of x/y/z appended
        //return list of tiles as output
        //TODO: Maybe add in more data to Selection Grid? Edge value would be useful if there are other move options than 'walk 1 step'
        //TODO: Perhaps include more data to Map? Right now there are no edge data, just neighbour data from logical inference which isn't the same thing
        //If we add in edge data, we can do something like 'Walk -> Tile[]', 'Wall-run -> Tile[]' which just provides a list of tiles a unit can access with certain Moves
        //TODO: Consider using threads? It will involve making Map threadsafe, but otherwise it seems like a good idea since it would divide the work up 4 ways minimum
        public static Move_Grid createGrid(Move inputMove, Map inputMap, Tile origin)
        {
            HashSet<String> marker = new HashSet<String>();

        }

    }
}

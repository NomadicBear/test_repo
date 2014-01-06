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
        //TODO: Perhaps include more data to Map? Right now there are no edge data, just neighbour data from logical inference which isn't the same thing
        //If we add in edge data, we can do something like 'Walk -> Tile[]', 'Wall-run -> Tile[]' which just provides a list of tiles a unit can access with certain Moves
        //TODO: Consider using threads? It will involve making Map threadsafe, but otherwise it seems like a good idea since it would divide the work up 4 ways minimum
        public static Move_Grid createGrid(Move inputMove, Map inputMap, Tile origin)
        {
            //HashSet<Tile> tracker = new HashSet<Tile>(); //Keeps track of what tiles have been explored
            Move_Grid output = new Move_Grid();

            Stack<Tile> travel_stack = new Stack<Tile>();
            Tile[] neighbours = inputMap.getNeighbours(origin);

            foreach (Tile tile in neighbours)
            {
                travel_stack.Push(tile);
            }

            //Start DFS here
            Stack<Tile> branch_stack = new Stack<Tile>();  //Used to simulate the benefits of recursing - store the branch points to enable distance/cost tracking
            int current_moves = inputMove.horizontal_movement_range - 1;    //one move taken for neighbours
            int distance_from_origin = 1;
            Tile current_tile;
            bool branch_out;

            //assuming there are still neighbours to resolve
            while (travel_stack.Count != 0)
            {
                current_tile = travel_stack.Peek();
                branch_out = true;

                //working on tile
                if (!output.containsTile(current_tile))
                {
                    //unexplored tile
                    branch_stack.Push(current_tile);

                    //mark and add tile to move grid
                    output.addTile(current_tile, distance_from_origin, distance_from_origin, branch_stack.ToList());
                }
                else
                {
                    //explored tile; can only be a branch or loop

                    //might be a branch; attempt to resolve branches
                    if (branch_stack.Peek().Equals(current_tile))   //branch is complete; pop branching tile
                    {
                        branch_stack.Pop();
                        travel_stack.Pop();

                        distance_from_origin--;
                        current_moves++;
                        branch_out = false;
                    }
                    else //might be a loop; attempt to resolve loop
                    {
                        //compare cost
                        if (output.comparePath(current_tile, distance_from_origin) == -1)
                        {
                            //better path found
                            branch_stack.Push(current_tile);

                            //replace old path
                            output.replaceTile(current_tile, distance_from_origin, distance_from_origin, branch_stack.ToList());
                        }
                        else
                        {
                            //old path was better; dead end
                            travel_stack.Pop();
                            branch_out = false;
                        }
                    }
                }

                //attempt to branch into neighbours
                if (current_moves > 0 && branch_out == true)  //only branch if there are moves left and there's a chance for branching
                {
                    neighbours = inputMap.getNeighbours(current_tile);
                    if (neighbours.Length != 0)
                    {
                        foreach (Tile tile in neighbours)
                        {
                            travel_stack.Push(tile);
                        }
                        distance_from_origin++;
                        current_moves--;
                    }
                    else
                    {
                        branch_stack.Pop();
                        travel_stack.Pop(); //No neighbours; end of the line
                    }
                }
                else
                {
                    branch_stack.Pop();
                    travel_stack.Pop(); //No moves left; end of the line
                }

            }

            return output;
        }

    }
}

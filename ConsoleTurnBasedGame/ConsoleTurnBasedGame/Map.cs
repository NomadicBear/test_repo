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
        Tile[][][] tile_map;
        int size_x, size_y, size_z;
        int tile_count;

        public Map(string mapFile)
        {
            translateBaseMap(mapFile);
        }

        public void testPrintMap()
        {
            if (tile_count > 0)
            {
                Console.WriteLine("Tiles: {0}", tile_count);
                Console.WriteLine("Dimensions: X{0}, Y{1}, Z{2}", size_x, size_y, size_z);
                Console.Write("\n");

                int x, y, z;
                for (y = 0; y < tile_map.Length; y++)
                {
                    float temp_y = y / 10f;
                    Console.Write("Level: {0}\n", temp_y);
                    for (z = 0; z < tile_map[y].Length; z++)
                    {
                        for (x = 0; x < tile_map[y][z].Length; x++)
                        {
                            if (tile_map[y][z][x] != null)
                            {
                                Tile tempTile = tile_map[y][z][x];
                                switch (tempTile.terrain)
                                {
                                    case Terrain.GRASSLAND:
                                        Console.Write("G");
                                        break;
                                    case Terrain.PLAIN:
                                        Console.Write("P");
                                        break;
                                    case Terrain.WETLAND:
                                        Console.Write("W");
                                        break;
                                    default:
                                        Console.Write("?");
                                        break;
                                }
                            }
                            else
                            {
                                Console.Write(".");
                            }
                            if (x + 1 != size_x)
                            {
                                Console.Write(" ");
                            }
                        }
                        Console.Write("\n");
                    }
                    Console.Write("\n");
                }
            }
        }

        public Unit returnUnit(int x, int y, int z)
        {
            return returnTile(x, y, z).occupant;
        }

        public Tile returnTile(int x, int y, int z)
        {
            return tile_map[y][z][x];
        }

        private void translateBaseMap(String inputFile)
        {
            int x = 0;
            int y = 0;
            int z = 0;
            Tile[][][] output = null;

            int tileCounter = 0;

            //replaces tile_map, tile_count
            using (StreamReader reader = new StreamReader(inputFile))
            {
                int current_y = -1;
                int current_z = -1;
                int current_x = 0;

                string currentLine;
                Console.WriteLine("Starting parse..");
                while ((currentLine = reader.ReadLine()) != null)
                {
                    //Parsing map size here
                    if (currentLine.StartsWith("size_x:"))
                    {
                        int.TryParse(currentLine.Substring(7), out x);
                        Console.WriteLine("Size x:{0}", x);
                    }

                    if (currentLine.StartsWith("size_y:"))
                    {
                        int.TryParse(currentLine.Substring(7), out y);
                        Console.WriteLine("Size y:{0}", y);
                    }
                    if (currentLine.StartsWith("size_z:"))
                    {
                        int.TryParse(currentLine.Substring(7), out z);
                        Console.WriteLine("Size z:{0}", z);
                    }

                    //Parsing levels here
                    //Only start if map is created
                    if (output != null)
                    {
                        if (current_y > -1 && current_z < z)
                        {
                            string[] tempArray = currentLine.Split(' ');
                            current_x = 0;
                            foreach (string tile in tempArray)
                            {
                                Tile newTile = null;
                                switch (tile[0])
                                {
                                    case 'G':
                                        newTile = new Tile(current_x, current_y, current_z);
                                        newTile.terrain = Terrain.GRASSLAND;
                                        break;
                                    case 'P':
                                        newTile = new Tile(current_x, current_y, current_z);
                                        newTile.terrain = Terrain.PLAIN;
                                        break;
                                    case 'W':
                                        newTile = new Tile(current_x, current_y, current_z);
                                        newTile.terrain = Terrain.WETLAND;
                                        break;
                                    default:
                                        break;
                                }

                                output[current_y][current_z][current_x] = newTile;
                                if (newTile != null)
                                {
                                    tileCounter++;
                                }
                                current_x++;
                            }
                            current_z++;
                        }

                        if (currentLine.StartsWith("level:"))
                        {
                            Console.WriteLine("Parsing level");
                            int.TryParse(currentLine.Substring(6), out current_y);
                            current_z = 0;
                        }
                        if (currentLine.StartsWith("endlevel"))
                        {
                            Console.WriteLine("End of level parse");
                            current_y = -1;
                            current_z = -1;
                        }

                    }

                    //Create map container
                    if (x > 0 && y > 0 && z > 0 && output == null)
                    {
                        Console.WriteLine("Creating container");
                        output = new Tile[y][][];
                        int i, j;
                        for (i = 0; i < y; i++)
                        {
                            output[i] = new Tile[z][];
                            for (j = 0; j < z; j++)
                            {
                                output[i][j] = new Tile[x];
                            }
                        }
                    }
                }

                if (tileCounter > 0)
                {
                    Console.WriteLine("Filling in map data");
                    tile_map = output;
                    size_x = x;
                    size_y = y;
                    size_z = z;
                    tile_count = tileCounter;
                }
            }
        }
    }
}

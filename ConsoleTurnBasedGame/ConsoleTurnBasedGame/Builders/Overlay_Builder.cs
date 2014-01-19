using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleTurnBasedGame
{
    static class Overlay_Builder
    {
        //This is a simple array of units representing a tile overlay generator
        //Overlays can be custom-made using a text representation
        //Or generated using a template
        public static void testPrintOverlay(Overlay inputOverlay)
        {
            int i, j;

            //Initiate Overlay_Tile 2d array
            Overlay_Tile[][] printArray = new Overlay_Tile[inputOverlay.max_z][];
            for (i = 0; i < inputOverlay.max_z; i++)
            {
                printArray[i] = new Overlay_Tile[inputOverlay.max_x];
            }

            //Build Overlay_Tile 2d array from 1d array
            foreach (Overlay_Tile tile in inputOverlay.overlay_map)
            {
                //input.max_x/z will always be an odd number
                //Arrays start from 0, so diving by 2 gives you the middle due to int trunc
                int translated_x, translated_z;

                if (tile.relative_x > 0)
                {
                    translated_x = (inputOverlay.max_x / 2) + tile.relative_x;
                }
                else if (tile.relative_x == 0)
                {
                    translated_x = (inputOverlay.max_x / 2);
                }
                else
                {
                    translated_x = (inputOverlay.max_x / 2) - (tile.relative_x * -1);
                }

                if (tile.relative_z > 0)
                {
                    translated_z = (inputOverlay.max_z / 2) + tile.relative_z;
                }
                else if (tile.relative_z == 0)
                {
                    translated_z = (inputOverlay.max_z / 2);
                }
                else
                {
                    translated_z = (inputOverlay.max_z / 2) - (tile.relative_z * -1);
                }

                printArray[translated_z][translated_x] = tile;
            }

            //Print Overlay_Tile 2d array
            for (i = 0; i < inputOverlay.max_z; i++)
            {
                for (j = 0; j < inputOverlay.max_x; j++)
                {
                    if (printArray[i][j] != null)
                    {
                        Console.Write("X ");
                    }
                    else
                    {
                        Console.Write(". ");
                    }
                }
                Console.WriteLine("");
            }
        }

        public static Overlay createViaTemplate(Overlay_Template template, Y_Direction y_type, Boolean include_origin, int y_origin, float y_growth_rate, int x_value, int z_growth_rate)
        {

            return null;
        }

        //NOTE: Everything to the left/above the origin is negative valued, everything to the right and below is positive valued
        public static Overlay createViaFile(String inputFile)
        {
            List<Overlay_Tile> temp_overlay = new List<Overlay_Tile>();
            int x_value = -1;
            int z_value = -1;

            using (StreamReader reader = new StreamReader(inputFile))
            {
                int current_x_value = -1;
                int current_z_value = -1;
                int current_y_value = -1;
                Y_Direction current_direction;
                string currentLine;

                while ((currentLine = reader.ReadLine()) != null)
                {
                    if (x_value > 0 && z_value > 0)
                    {
                        Console.WriteLine("Parsing map..");
                        string[] tempArray = currentLine.Split(' ');

                        foreach (string temp in tempArray)
                        {
                            Overlay_Tile newOverlay_Tile;
                            if (temp != "...")
                            {
                                int.TryParse(currentLine.Substring(0, 1), out current_y_value);
                                switch (currentLine.Substring(2))
                                {
                                    case "N":
                                        current_direction = Y_Direction.NONE;
                                        break;
                                    case "U":
                                        current_direction = Y_Direction.UP;
                                        break;
                                    case "D":
                                        current_direction = Y_Direction.DOWN;
                                        break;
                                    case "B":
                                        current_direction = Y_Direction.BOTH;
                                        break;
                                    default:
                                        current_direction = Y_Direction.NONE;
                                        break;
                                }
                                newOverlay_Tile = new Overlay_Tile(current_x_value, current_z_value, current_y_value, current_direction);
                                temp_overlay.Add(newOverlay_Tile);
                            }
                            current_z_value++;
                        }
                        current_x_value++;
                        current_z_value = z_value * -1;
                    }

                    //Parsing variables
                    if (currentLine.StartsWith("x_value:"))
                    {
                        int.TryParse(currentLine.Substring(8), out x_value);
                        current_x_value = x_value * -1;
                        Console.WriteLine("x_value:{0}", x_value);
                    }

                    if (currentLine.StartsWith("z_value:"))
                    {
                        int.TryParse(currentLine.Substring(8), out z_value);
                        current_z_value = z_value * -1;
                        Console.WriteLine("z_value:{0}", z_value);
                    }
                }
            }

            return new Overlay(temp_overlay.ToArray(), (x_value * 2) + 1, (z_value * 2) + 1); ;
        }

        public static Overlay createTest()
        {
            return null;
        }

        public static Overlay combineTemplates(Overlay orignal, Overlay addition, Boolean overwrite)
        {
            return null;
        }

        public enum Overlay_Template
        {
            DIAMOND,    //A diamond shape surrounding the origin
            SQUARE, //A square shape surrounding the origin
            ORB,    //Same as Diamond, but with wider points to simulate a circle
            CONE,   //A cone shape extending from the origin - does not include origin by default
            BEAM,   //A pillar of tiles extending in the x axis from origin - does not include origin by default
            TUNNEL  //Same as beam, but extends both ways and encompasses the origin
        }

        public enum Y_Growth_Type
        {
            EQUAL,  //Start at y_origin at origin and maintain y_origin every step to edge
            LINEAR, //Start at y_origin at origin, increasing by y_growth_rate every step towards the edge
            REVERSE_LINEAR, //Start at y_origin at origin, decreasing by y_growth_rate every step towards the edge
            INFINITE    //Overwrite y_origin and y_growth, set y_value for each at -1
        }
    }
}

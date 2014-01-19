using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTurnBasedGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string testDirectory = Environment.CurrentDirectory;
            Console.Write(testDirectory);
            Console.ReadLine();

            //Map testing
            string mapPath = testDirectory + @"\testfiles\testmap.txt";
            Map testMap = Map_Builder.loadMap(mapPath);
            Map_Builder.testPrintMap(testMap);
            Console.ReadLine();

            //Overlay testing
            string overlayPath = testDirectory + @"\testfiles\testoverlay.txt";
            Overlay overlay = Overlay_Builder.createViaFile(overlayPath);
            Overlay_Builder.testPrintOverlay(overlay);
            Console.ReadLine();

            //Action testing


            //Action_Grid testing


            //Move_Grid testing

            
            //Move testing
            
            
            //Unit testing
            
            
            //Turn_Controller testing

        }
    }
}

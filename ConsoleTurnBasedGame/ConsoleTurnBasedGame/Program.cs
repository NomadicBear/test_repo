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

            string mapPath = testDirectory + @"\testfiles\testmap.txt";
            Map testMap = Map_Builder.loadMap(mapPath);
            Map_Builder.testPrintMap(testMap);
            Console.ReadLine();

            string overlayPath = testDirectory + @"\testfiles\testoverlay.txt";
            Overlay overlay = Overlay_Builder.createViaFile(overlayPath);
            Overlay_Builder.testPrintOverlay(overlay);
             
            Console.ReadLine();

        }
    }
}

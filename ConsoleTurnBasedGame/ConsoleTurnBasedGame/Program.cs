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
            Map testMap = new Map(mapPath);
            testMap.testPrintMap();
            Console.ReadLine();

            string overlayPath = testDirectory + @"\testfiles\testoverlay.txt";
            Overlay overlay = Overlay_Generator.createViaFile(overlayPath);
            Overlay_Generator.testPrintOverlay(overlay);
            Console.ReadLine();

        }
    }
}

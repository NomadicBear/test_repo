using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTurnBasedGame
{
    class Action_Builder
    {
        //Read external data/file
        //Create new Action
        //Set Action attributes
        //Create Overlay by either file or template data (depends on Action data)
        //Attach Overlay
        //Return Action
        public static Action loadAction(string inputFile)
        {
            return null;
        }

        //'basic attack' action for prototype use
        public static Action createTestAction()
        {
            string overlay_path = Environment.CurrentDirectory + @"\testfiles\basic_attack_overlay.txt";
            Overlay new_overlay = Overlay_Builder.createViaFile(overlay_path);

            return new Action(new_overlay, 10);
        }
    }
}

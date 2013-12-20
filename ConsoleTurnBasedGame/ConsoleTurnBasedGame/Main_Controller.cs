using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTurnBasedGame
{
    class Main_Controller
    {
        Map map;
        Unit[] unit_list;
        Player[] player_list;
        Turn_Controller turn_controller;
        Boolean initiation_done;
        Boolean control_loop_active;
        Boolean end_game_start;

        //Issues orders and referees the game
        //Steps: 
        /* -Preparation-
         * Create players - main_controller
         * Create units - unit_manager/action_manager/move_manager
         * Players assigned units   - main_controller
         * Sort units by initiative - turn_controller
         * -Gameplay-
         * Players deploy units - main_controller/input/graphics
         * -Control Phase-
         * Turn control loop start: highest initiatve unit goes first   - turn_controller
         * Calculate and attach action overlay - overlay_manager/main_controller
         * Calculate move overlay - overlay_manager/main_controller
         * Player gains control over unit   - main_controller/input/graphics
         * Unit chooses an action (movement, activation, attack)    - main_controller/input/graphics
         * -Action Phase-
         * Unit takes action/Affect Units take counteraction    - action_controller
         * Action consequences are calculated   - action_controller
         * Player ends turn or turn ends automatically upon unit exhaustion
         * Turn control end: check units left/main objectives
         * -Endgame-
         * Last unit falls for a player/objectives achieved by a player
         * Rewards generated, experience calculated
         */

        void initiationTest()
        {
            //Create two players  - TODO: use a builder for this?
            Player player1 = new Player("Player 1");
            Player player2 = new Player("Player 2");
            
            //Add players to array
            player_list = new Player[2]{player1, player2};
            
            //Create two units
            Unit unit1 = Unit_Builder.createTestUnit();
            Unit unit2 = Unit_Builder.createTestUnit();

            //Add units to players - TODO: use a builder for this?
            player1.unit_list.Add(unit1);
            unit1.owner = player1;
            player2.unit_list.Add(unit2);
            unit2.owner = player2;

            //Add units to turn list
            List<Unit> templist = new List<Unit>();
            templist.Add(unit1);
            templist.Add(unit2);
            turn_controller = new Turn_Controller(templist);
            templist.Clear();

            //Calculate overlays for each unit
            //Display: Game start - board, units, menus
            //
        }
    }
}

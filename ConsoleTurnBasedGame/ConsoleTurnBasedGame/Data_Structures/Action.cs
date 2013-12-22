using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTurnBasedGame
{
    class Action
    {
        public Overlay overlay;
        public Selection_Grid selection_grid;
        public int attack_power;

        public Action(Overlay newOverlay, int newAttack_power)
        {
            overlay = newOverlay;
            attack_power = newAttack_power;

            selection_grid = null;
        }
    }
}

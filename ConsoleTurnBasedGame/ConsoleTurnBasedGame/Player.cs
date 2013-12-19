using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTurnBasedGame
{
    class Player
    {
        public int priority { get; set; }   //This should set on game start
        public string name { get; private set; }
        public List<Unit> unit_list;

        public Player(string newName)
        {
            name = newName;
            unit_list = new List<Unit>();
            priority = 0;
        }
    }
}

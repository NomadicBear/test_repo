using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTurnBasedGame
{
    class Unit
    {
        //The four attributes below should be set after class creation
        public int id { get; set; }
        public Player owner { get; set; }
        public Tile anchor_tile { get; set; }
        public Direction face_direction { get; set; }

        public float health { get; set; }
        public float max_health { get; set; }

        public int attack_power { get; set; }

        public int horizontal_movement_range { get; set; }  //Moving in horizontal planes
        public int vertical_movement_range { get; set; }    //Moving in vertical planes

        public float initiative { get; set; }

        List<Action> actions;   //TODO: This looks like a good place to split up into more specific lists, like Spells/Class Skills/Item, etc.
        List<Move> moves;

        public Boolean turn_taken;

        public Unit()
        {
            health = 100;
            max_health = 100;

            attack_power = 10;

            horizontal_movement_range = 3;
            vertical_movement_range = 3;

            initiative = 1;

            turn_taken = true;

            actions = new List<Action>();
            moves = new List<Move>();
        }

        public Unit(float newHealth, float newMax_health, int newAttack_power, 
            int newHorizontal_movement_range, int newVertical_movement_range,
            float newInitiative)
        {
            health = newHealth;
            max_health = newMax_health;

            attack_power = newAttack_power;

            horizontal_movement_range = newHorizontal_movement_range;
            vertical_movement_range = newVertical_movement_range;

            initiative = newInitiative;

            turn_taken = true;

            actions = new List<Action>();
            moves = new List<Move>();
        }

        public void addAction(Action newAction)
        {
            if (newAction != null)
            {
                actions.Add(newAction);
            }
        }

        public void addMove(Move newMove)
        {
            if (newMove != null)
            {
                moves.Add(newMove);
            }
        }
    }

    enum Direction
    {
        NORTH,
        SOUTH,
        EAST,
        WEST
    }
}

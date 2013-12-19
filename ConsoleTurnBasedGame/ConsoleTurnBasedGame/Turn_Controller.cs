using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTurnBasedGame
{
    class Turn_Controller
    {
        List<Unit> unit_list;
        int turn_counter;
        List<Unit> turn_list;
        //List<Unit> standby_list;
        Unit currentUnit;

        //WARNING: This logic is controlled from OUTSIDE of this class
        //The game starts
        //Units are added to unit list  - initialize
        //Units are sorted according to initiative  - newRound()
        //Units are tossed into turn list
        //Turn starts; first unit from turn list is popped  - takeTurn()
        //Unit is given AP, stamina, buff/debuff unit owns are considered
        //When a unit finishes its turn, it goes into the standbylist
        //If a unit decides to wait on another unit, it is readded to the turn list - delayTurn()
        //When turn list is expended, the turn is over

        public void orderUnits()
        {
            //unit_list.Sort(new CompareInitiative());
        }

        public Turn_Controller()
        {
            unit_list = new List<Unit>();
            turn_list = new List<Unit>();
            //standby_list = new List<Unit>();
            currentUnit = null;

            turn_counter = 0;
        }

        public Turn_Controller(List<Unit> newUnit_list)
        {
            unit_list = new List<Unit>(newUnit_list);
            turn_list = new List<Unit>();
            //standby_list = new List<Unit>();
            currentUnit = null;

            turn_counter = 0;
        }

        public Unit nextUnit()
        {
            return turn_list[0];
        }

        public void newRound()
        {
            unit_list.Sort(new CompareInitiative());

            turn_list.Clear();
            //standby_list.Clear();
            turn_list = new List<Unit>(unit_list);
            turn_counter++;
        }

        public void takeTurn()
        {
            Unit nextUnit = turn_list[0];
            turn_list.RemoveAt(0);  //Remove next unit from turn_list first

            if (currentUnit != null)    //Accounting for turn 1
            {
                //standby_list.Add(currentUnit);  //Place currentUnit in standby_list
                currentUnit.turn_taken = true;
            }

            currentUnit = nextUnit;  //Replace current unit with next unit
        }

        public void delayTurn(Unit target)
        {
            Unit nextUnit = turn_list[0];
            turn_list.RemoveAt(0);  //Remove next unit from turn_list first

            
            int targetPosition = turn_list.FindIndex(
                delegate(Unit u)
                {
                    return u.id == target.id;
                }
            );

            turn_list.Insert(targetPosition + 1, currentUnit);  //Place currentUnit back into turn_list
            currentUnit = nextUnit;  //Replace current unit with next unit
        }


        //TODO: Check for validity
        public void delayToLast(Unit target)
        {
            Unit currentLast = turn_list[turn_list.Count - 1];
            
            turn_list.Remove(target);

            switch (new CompareInitiative().Compare(currentLast, target))
            {
                case 1:
                    turn_list.Add(target);
                    break;
                case -1:
                    turn_list.Insert(turn_list.Count - 2, target);
                    break;
                default:
                    Console.WriteLine();
                    Console.WriteLine("Error in CompareInitiative");
                    break;
            }
        }

        //This has to be outside of Overlay_Manager class since it needs the Map
        //Get unit location
        //Depending on unit movement passives, determine which tiles unit can access from current tile in 1 move
        //Mark a reached tile using a dictionary
        //Reduce amount of movement unit has by 1
        //Repeat for each tile reached until movement reaches 0
        Overlay createMoveOverlay(Unit unit)
        {
            //This is under the assumption that each unit is 1 square in size and height
            return null;
        }

        class CompareInitiative : Comparer<Unit>
        {
            public override int Compare(Unit x, Unit y)
            {
                if (x.initiative == y.initiative)
                {
                    if (x.owner.priority > y.owner.priority)
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
                if (x.initiative > y.initiative)
                {
                    return 1;
                }
                if (x.initiative < y.initiative)
                {
                    return -1;
                }

                return 0;
            }
        }
    }
}

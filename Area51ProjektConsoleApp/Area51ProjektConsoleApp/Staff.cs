using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area51ProjektConsoleApp
{
    public class Staff
    {
        public Staff(List<Floor> floors)
        {
            SecurityClearance = RNG.RandomNumberGenerator(0,5);
            AtFloor = floors[RNG.RandomNumberGenerator(1,floors.Count)];
            TargetFloor = floors[RNG.RandomNumberGenerator(1, floors.Count)];
            //will make the staffmember needing to move
            while(AtFloor == TargetFloor)
            {
                TargetFloor = floors[RNG.RandomNumberGenerator(1, floors.Count)];
            }
            Living = true;
            Name = textFile[RNG.RandomNumberGenerator(1, textFile.Length)];
        }
        public int SecurityClearance { get; set; }
        public Floor AtFloor { get; set; }
        public Floor TargetFloor { get; set; }
        public bool Living { get; set; }
        public string Name { get; set; }
        static readonly string[] textFile = File.ReadAllLines(@"C:\Users\chri615w\source\repos\Area-51-Projekt\names.txt");

        public void StaffBehavior(Base homeBase)
        {
            // can only do things if they are alive
            if (this.Living == true)
            {
                //checks if any elevator is on this floor and if there are anyone inside it. Then tries too use it and go to their wanted floor
                foreach (Elevator elevator in homeBase.Elevator)
                {
                    if(elevator.AtFloor == this.AtFloor)
                    {
                        if (elevator.StaffEntersElevator(this))
                        {
                            elevator.FloorPanel.SendElevatorToFloor();
                            break;
                        }
                    }
                }
                // staff makes a request for an elevator to get too their current floor
                if (this.TargetFloor != this.AtFloor)
                {
                    homeBase.Floors.Find(x => x == this.AtFloor).Panel.RequestElevator(this,homeBase.Elevator[RNG.RandomNumberGenerator(0, homeBase.Elevator.Count())]);
                }
            }
        }
    }
}

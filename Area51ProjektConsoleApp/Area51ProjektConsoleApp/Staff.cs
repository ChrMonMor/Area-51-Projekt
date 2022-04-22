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
            SecurityClearance = RNG.RandomNumberGenerator(floors.First().GetSecurityClearance(), floors.Last().GetSecurityClearance()+1);
            AtFloor = floors[RNG.RandomNumberGenerator(floors.First().FloorNumber, floors.Last().FloorNumber + 1)];
            TargetFloor = floors[RNG.RandomNumberGenerator(floors.First().FloorNumber, floors.Last().FloorNumber+1)];
            //will make the staffmember needing to move
            while(AtFloor == TargetFloor)
            {
                TargetFloor = floors[RNG.RandomNumberGenerator(floors.First().FloorNumber, floors.Last().FloorNumber+1)];
            }
            Living = true;
            Name = textFile[RNG.RandomNumberGenerator(1, textFile.Length)];
        }
        private int SecurityClearance { get; set; }
        public Floor AtFloor { get; set; }
        private Floor TargetFloor { get; set; }
        public bool Living { get; set; }
        public string Name { get; set; }
        private static readonly string[] textFile = File.ReadAllLines(@"C:\Users\chri615w\source\repos\Area-51-Projekt\names.txt");

        public void StaffBehavior(Base homeBase)
        {
            // can only do things if they are alive
            if (Living == true)
            {
                if (AtFloor.FloorNumber != TargetFloor.FloorNumber)
                {
                    //checks if any elevator is on this floor and if there are anyone inside it. Then tries too use it and go to their wanted floor
                    for (int i = 0; i < homeBase.Elevators.Count(); i++)
                    {
                        if (homeBase.Elevators[i].AtFloor.FloorNumber == AtFloor.FloorNumber)
                        {
                            if (homeBase.Elevators[i].StaffEntersElevator(this))
                            {
                                homeBase.Elevators[i].GetFloorPanel().SendElevatorToFloor();
                                break;
                            }
                        }
                        else
                        {
                            homeBase.Floors[AtFloor.FloorNumber].GetPanel().RequestElevator(this, homeBase.Elevators[i]);
                        }
                    }
                }
            }
        }
        public int GetSecurityClearance()
        {
            return SecurityClearance;
        }
        public Floor GetTargetFloor()
        {
            return TargetFloor;
        }
    }
}

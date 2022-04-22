using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area51ProjektConsoleApp
{
    public class Base
    {
        public Base()
        {
            Elevators = ElevatorArray();
            Floors = FloorList();
            Staffs = StaffArray();
            AllStaffIsNotHappy = true;
        }

        private Elevator[] ElevatorArray()
        {
            Elevator[] elevators = new Elevator[] { new Elevator(FloorList()) };
            return elevators;
        }
        private List<Floor> FloorList()
        {
            List<Floor> floors = new List<Floor> { new Floor(0), new Floor(1), new Floor(2), new Floor(3), new Floor(4), new Floor(5) };
            return floors;
        }
        private Staff[] StaffArray()
        {
            Staff[] staffs = new Staff[20];
            for (int i = 0; i < staffs.Length; i++)
            {
                staffs[i] = new Staff(FloorList());
            }
            return staffs;
        }
        public  Elevator[] Elevators { get; set; }
        public  List<Floor> Floors { get; set; }
        private  Staff[] Staffs { get; set; }
        private bool AllStaffIsNotHappy { get; set; }
        public bool IsAllStaffHappy()
        {
            foreach(Staff staff in Staffs)
            {
                if (staff.Living)
                {
                    if (staff.AtFloor != staff.GetTargetFloor())
                    {
                        AllStaffIsNotHappy = true;
                        break;
                    }
                }
                AllStaffIsNotHappy = false;
            }
            return AllStaffIsNotHappy;
        }
        public void BaseBehavior()
        {
            for (int i = 0; i < SpawnStaff; i++)
            {
                Staffs[i].StaffBehavior(this);
            }
            if (SpawnStaff < Staffs.Count())
            {
                SpawnStaff += 1;
            }
            foreach (Elevator elevator in Elevators)
            {
                elevator.ElevatorBehavior();
            }
            foreach (Floor floor in Floors)
            {
                floor.GetCeilingTurret().ReloadingTurret();
            }
        }
        private static int SpawnStaff = 1; 
        // shows staff info to user
        public void AllStaffsNames()
        {
            Console.WriteLine("Name: \t\tHappy: \tAt: \tCan: \tWant: \tAlive:");
            for (int i = 0; i < SpawnStaff; i++)
            {
                if (Staffs[i].Name.Length > 7) { Console.Write(Staffs[i].Name.Substring(0, 7) + "\t"); }
                else { Console.Write(Staffs[i].Name + "\t"); }
                if (Staffs[i].AtFloor == Staffs[i].GetTargetFloor())
                {
                    Console.Write(" \ttrue");
                }
                else Console.Write(" \tfalse ");
                Console.Write("\t" + Staffs[i].AtFloor.FloorNumber);
                Console.Write("\t" + Staffs[i].GetSecurityClearance());
                Console.Write("\t" + Staffs[i].GetTargetFloor().FloorNumber);
                Console.WriteLine("\t" + Staffs[i].Living);
            }
        }
        //|------|-|-|
        //|0|  n |X|M|
        //|-|----|-|-|
        //|1|  N | |m|
        //|-|----|-|-|
        //|2|  n | |M|
        //|-|----|-|-|
        //|3|  N | |m|
        //|-|----|-|-|
        //|4|  n | |M|
        //|-|----|-|-|
        //|5|  N | |m|
        //|-|----|-|-|
        public void BuildingBase()
        {
            Console.WriteLine("---------------------|-|----|-|-|---------------------");
            for (int i = 0; i < Floors.Count; i++)
            {
                Console.Write("                     |{0}|  {1} |", Floors[i].FloorNumber, Staffs.Count(x => Floors[i].FloorNumber == x.AtFloor.FloorNumber && x.Living));
                if (Elevators.Any(x => Floors[i].FloorNumber == x.AtFloor.FloorNumber)) { Console.Write("X|"); } else { Console.Write(" |"); }
                Console.WriteLine("{0}|", Staffs.Count(x=> Floors[i].FloorNumber == x.AtFloor.FloorNumber && !x.Living));
                Console.WriteLine("                     |-|----|-|-|");
            }
        }
        public void AllStaffsNamesButRemovingDead()
        {
            Console.WriteLine("Name: \t\tHappy: \tAt: \tCan: \tWant: \tAlive:");
            for (int i = 0; i < SpawnStaff; i++)
            {
                if (Staffs[i].Living)
                {
                    if (Staffs[i].Name.Length > 7) { Console.Write(Staffs[i].Name.Substring(0, 7) + "\t"); }
                    else { Console.Write(Staffs[i].Name + "\t"); }
                    if (Staffs[i].AtFloor == Staffs[i].GetTargetFloor())
                    {
                        Console.Write(" \ttrue");
                    }
                    else Console.Write(" \tfalse ");
                    Console.Write("\t" + Staffs[i].AtFloor.FloorNumber);
                    Console.Write("\t" + Staffs[i].GetSecurityClearance());
                    Console.Write("\t" + Staffs[i].GetTargetFloor().FloorNumber);
                    Console.WriteLine("\t" + Staffs[i].Living);
                }
            }
        }
    }
}

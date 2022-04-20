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
            Controller = new Controller();
            Elevators = ElevatorArray();
            Floors = FloorList();
            Staffs = StaffArray();
            AllStaffIsHappy = false;
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
        public  Controller @Controller { get; set; }
        public  Elevator[] Elevators { get; set; }
        public  List<Floor> Floors { get; set; }
        public  Staff[] Staffs { get; set; }
        public bool AllStaffIsHappy { get; set; }

        public void TurnStaff(Staff staff)
        {
            staff.StaffBehavior(this);
        }
        public void TurnElevator(Elevator elevator)
        {
            if (elevator.Rider == null)
            {
                elevator.GotoFloor();
            }
            elevator.SetDelayingElevator();
        }
        public void ReloadTurrets()
        {
            foreach(Floor floor in Floors)
            {
                floor.CeilingTurret.ReloadingTurret();
            }
        }
        public void IsAllStaffHappy()
        {
            foreach(Staff staff in Staffs)
            {
                if (staff.Living)
                {
                    if (staff.AtFloor != staff.TargetFloor)
                    {
                        AllStaffIsHappy = false;
                        break;
                    }
                }
                AllStaffIsHappy = true;
            }
        }
        // shows staff info to user
        public void AllStaffsNames()
        {
            Console.WriteLine("Name: \t\tHappy: \tAt: \tCan: \tWant: \tAlive:");
            foreach(Staff staff in Staffs)
            {
                if (staff.Name.Length > 7) { Console.Write(staff.Name.Substring(0, 7) + "\t"); }
                else { Console.Write(staff.Name + "\t"); }
                if (staff.AtFloor == staff.TargetFloor)
                {
                    Console.Write(" \ttrue");
                }
                else Console.Write(" \tfalse ");
                Console.Write("\t" + staff.AtFloor.FloorNumber);
                Console.Write("\t" + staff.SecurityClearance);
                Console.Write("\t" + staff.TargetFloor.FloorNumber);
                Console.WriteLine("\t" + staff.Living);
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
            foreach (Staff staff in Staffs)
            {
                if (staff.Living)
                {
                    if (staff.Name.Length > 7) { Console.Write(staff.Name.Substring(0, 7) + "\t"); }
                    else { Console.Write(staff.Name + "\t"); }
                    if (staff.AtFloor == staff.TargetFloor)
                    {
                        Console.Write(" \ttrue");
                    }
                    else Console.Write(" \tfalse ");
                    Console.Write("\t" + staff.AtFloor.FloorNumber);
                    Console.Write("\t" + staff.SecurityClearance);
                    Console.Write("\t" + staff.TargetFloor.FloorNumber);
                    Console.WriteLine("\t" + staff.Living);
                }
            }
        }
        public void BaseBehavior()
        {
            foreach(Staff staff in Staffs)
            {
                TurnStaff(staff);
            }
            foreach(Elevator elevator in Elevators)
            {
                TurnElevator(elevator);
            }
            ReloadTurrets();
        }
    }
}

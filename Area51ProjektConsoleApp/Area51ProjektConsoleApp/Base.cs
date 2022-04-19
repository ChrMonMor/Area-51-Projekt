﻿using System;
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
            Elevator = Elevators();
            Floors = FloorList();
            Staffs = StaffArray();
            AllStaffIsHappy = false;
        }

        private Elevator[] Elevators()
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
        public  Elevator[] Elevator { get; set; }
        public  List<Floor> Floors { get; set; }
        public  Staff[] Staffs { get; set; }
        public bool AllStaffIsHappy { get; set; }

        public void TurnStaff(Staff staff)
        {
            staff.StaffBehavior(this);
        }
        public void TurnElevator(Elevator elevator)
        {
            if (elevator.Rider == null && elevator.TravelQueue.Any())
            {
                elevator.GotoFloor();
            }
        }
        public void IsAllStaffHappy()
        {
            foreach(Staff staff in this.Staffs)
            {
                if (staff.Living)
                {
                    if (staff.AtFloor != staff.TargetFloor)
                    {
                        this.AllStaffIsHappy = false;
                        break;
                    }
                }
                this.AllStaffIsHappy = true;
            }
        }
        public void AllStaffsNames()
        {
            foreach(Staff staff in this.Staffs)
            {
                Console.Write(staff.Name);
                if (staff.AtFloor == staff.TargetFloor)
                {
                    Console.Write(" true ");
                }
                else Console.Write(" false ");
                Console.Write(staff.AtFloor.FloorNumber);
                Console.Write(" "+staff.SecurityClearance);
                Console.WriteLine(" " + staff.Living);
            }
        }

    }
}

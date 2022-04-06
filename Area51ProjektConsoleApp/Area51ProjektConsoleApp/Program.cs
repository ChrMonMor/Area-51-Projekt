using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area51ProjektConsoleApp
{
    public class Program
    {
        public Program()
        {
            Elevator = new Elevator(FloorList());
            Floors = FloorList();
            Staffs = StaffArray();
        }
        private List<Floor> FloorList()
        {
            List<Floor> floors = new List<Floor>{ new Floor(0), new Floor(1), new Floor(2), new Floor(3), new Floor(4), new Floor(5)};
            return floors;
        }
        private Staff[] StaffArray()
        {
            Staff[] staffs = new Staff[Staffs.Length];
            for (int i = 0; i < staffs.Length; i++)
            {
                staffs[i] = new Staff(FloorList());
            }
            return staffs;
        }

        public static Elevator Elevator { get; set; }
        public static List<Floor> Floors { get; set; }
        public static Staff[] Staffs { get; set; }
        static void Main(string[] args)
        {
            Program program = new Program();
        }
    }
}

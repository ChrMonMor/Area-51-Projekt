using System;
using System.Collections.Generic;
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
        }
        public int SecurityClearance { get; set; }
        public Floor AtFloor { get; set; }
        public Floor TargetFloor { get; set; }
        public bool Living { get; set; }
        
        public static void StaffBehavior(Staff staff)
        {
            if (staff.Living == true)
            {
                if (staff.TargetFloor != staff.AtFloor)
                {
                    Panel.RequestElevator(staff);
                }
            }
        }
    }
}

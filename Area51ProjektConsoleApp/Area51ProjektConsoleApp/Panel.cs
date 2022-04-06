using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area51ProjektConsoleApp
{
    public class Panel
    {
        static public void RequestElevator(Staff staff)
        {
            Scanner.StaffMember(staff);
            Controller.ElevatorRequestProcess(staff.TargetFloor);
        }
    }
}

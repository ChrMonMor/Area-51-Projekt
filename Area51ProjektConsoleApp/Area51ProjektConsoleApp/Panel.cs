using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area51ProjektConsoleApp
{
    public class Panel
    {
        private static Floor panel;

        public Panel(Floor floor)
        {
            panel = floor;
        }

        public void RequestElevator(Staff staff, Elevator elevator)
        {
            Controller.ElevatorRequestProcess(staff, panel, elevator);
        }
    }
}

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

        static public void RequestElevator(Elevator elevator)
        {
            elevator.SendElevatorToRequestedFloor(panel);
        }
    }
}

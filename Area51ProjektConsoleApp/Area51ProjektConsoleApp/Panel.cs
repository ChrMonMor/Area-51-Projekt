using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area51ProjektConsoleApp
{
    public class Panel
    {
        private  Floor FloorPanel { get; set; }

        public Panel(Floor floor)
        {
            FloorPanel = floor;
        }

        public void RequestElevator(Staff staff, Elevator elevator)
        {
            Controller.ElevatorRequestProcess(staff, FloorPanel, elevator);
        }
    }
}

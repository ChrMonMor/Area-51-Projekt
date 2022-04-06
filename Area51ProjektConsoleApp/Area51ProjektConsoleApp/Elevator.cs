using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area51ProjektConsoleApp
{
    internal class Elevator
    {
        public Floor AtFloor { get; set; }
        public Floor TargetFloor { get; set; }
        public Staff Rider { get; set; }
        public Queue<Floor> TravelList { get; set; }
        public FloorPanel FloorPanel { get; set; }
    }
}

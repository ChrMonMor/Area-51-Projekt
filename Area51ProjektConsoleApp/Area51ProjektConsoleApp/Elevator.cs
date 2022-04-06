using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area51ProjektConsoleApp
{
    public class Elevator
    {
        public Elevator(List<Floor> floors)
        {
            AtFloor = floors[0];
            TargetFloor = null;
            Rider = null;
            TravelList = new Queue<Floor>();
            FloorPanel = new FloorPanel();
        }

        public Floor AtFloor { get; set; }
        public Floor TargetFloor { get; set; }
        public Staff Rider { get; set; }
        public Queue<Floor> TravelList { get; set; }
        public FloorPanel FloorPanel { get; set; }
        public static void AddToTravelList()
        {
            Program.Elevator.TravelList.Enqueue()


        }
    }
}

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
            TravelQueue = new Queue<Floor>();
            FloorPanel = new FloorPanel(this);
        }

        public  Floor AtFloor { get; set; }
        public  Floor TargetFloor { get; set; }
        public  Staff Rider { get; set; }
        public  Queue<Floor> TravelQueue { get; set; }
        public  FloorPanel FloorPanel { get; set; }
        public void GotoFloor()
        {
            Delaying.DelayTime(1000);
            this.AtFloor = this.TravelQueue.Peek();
            this.TravelQueue.Dequeue();
        }
        public void AddTooTravelQueue(Floor floor)
        {
            this.TravelQueue.Enqueue(floor);
        }
        public void SendElevatorToRequestedFloor()
        {
            Delaying.DelayTime(1000);
            this.AtFloor = this.TargetFloor;
        }
        public void RequstElevatorToGoToo(Floor floor)
        {
            this.TargetFloor = floor;
        }
        public bool StaffEntersElevator(Staff staff)
        {
            if(this.Rider == null)
            {
                this.Rider = staff;
                return true;
            }
            return false;
        }
        public void StaffExitsElevator(Staff staff)
        {
            staff.AtFloor = this.AtFloor;
            this.Rider = null;
        }
    }
}

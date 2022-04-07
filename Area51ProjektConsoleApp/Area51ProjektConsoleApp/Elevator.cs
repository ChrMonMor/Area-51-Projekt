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
            FloorPanel = new FloorPanel(this);
        }

        public  Floor AtFloor { get; set; }
        public  Floor TargetFloor { get; set; }
        public  Staff Rider { get; set; }
        public  Queue<Floor> TravelList { get; set; }
        public  FloorPanel FloorPanel { get; set; }
        public void AddToTravelList()
        {
            if (Controller.ElevatorRequestProcess())
            {

            }
        }
        // sends the elevator to target floor. Fire only if they are allow 
        private void GotoFloor()
        {
            Delaying.DelayTime(1000);
            this.AtFloor = this.TargetFloor;
        }
        public void SendElevatorToRequestedFloor(Floor floor)
        {
            Delaying.DelayTime(1000);
            this.AtFloor = floor;
        }
        public void RequstElevatorToGoToo(Floor floor)
        {
            this.TargetFloor = floor;
        }
        public void StaffEntersElevator(Staff staff)
        {
            if(this.Rider == null && staff != this.Rider)
            {
                this.Rider = staff;
            }
        }
        public void StaffExitsElevator(Staff staff)
        {
            staff.AtFloor = this.AtFloor;
            this.Rider = null;
        }
    }
}

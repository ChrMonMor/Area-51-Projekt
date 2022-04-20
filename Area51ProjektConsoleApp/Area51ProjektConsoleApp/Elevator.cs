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
            DelayingElevator = false;
        }

        public Floor AtFloor { get; set; }
        public Floor TargetFloor { get; set; }
        public Staff Rider { get; set; }
        public Queue<Floor> TravelQueue { get; set; }
        public FloorPanel FloorPanel { get; set; }
        private bool DelayingElevator { get; set; }
        public void GotoFloor()
        {
            if (TravelQueue.Any())
            {
                if (!DelayingElevator)
                {
                    if(AtFloor == TravelQueue.Peek())
                    {
                        TravelQueue.Dequeue();
                    }
                    else
                    {
                        AtFloor = TravelQueue.Peek();
                        TravelQueue.Dequeue();
                        DelayingElevator = true;
                    }
                }
            }
        }
        public void AddTooTravelQueue(Floor floor)
        {
            if (!TravelQueue.Contains(floor))
            {
                TravelQueue.Enqueue(floor);
            }
        }
        public void SendElevatorToRequestedFloor()
        {
            if (!DelayingElevator)
            {
                AtFloor = TargetFloor;
                StaffExitsElevator(Rider);
                DelayingElevator = true;
            }
        }
        public void RequstElevatorToGoToo(Floor floor)
        {
            TargetFloor = floor;
        }
        public bool StaffEntersElevator(Staff staff)
        {
            if(Rider == null || Rider == staff)
            {
                Rider = staff;
                return true;
            }
            return false;
        }
        public void StaffExitsElevator(Staff staff)
        {
            staff.AtFloor = AtFloor;
            Rider = null;
        }
        public void SetDelayingElevator()
        {
            DelayingElevator = false;
        }
    }
}

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
            DelayingElevator = Speed;
        }

        public Floor AtFloor { get; set; }
        private Floor TargetFloor { get; set; }
        private Staff Rider { get; set; }
        private Queue<Floor> TravelQueue { get; set; }
        private FloorPanel FloorPanel { get; set; }
        private int DelayingElevator { get; set; }
        private readonly int Speed = 1;
        public Floor GetTargetFloor()
        {
            return TargetFloor;
        }
        public Staff GetRider()
        {
            return Rider;
        }
        public FloorPanel GetFloorPanel()
        {
            return FloorPanel;
        }
        private void GotoFloor()
        {
            if (TravelQueue.Any())
            {
                if (DelayingElevator > 0)
                {
                    if(AtFloor == TravelQueue.Peek())
                    {
                        TravelQueue.Dequeue();
                    }
                    else
                    {
                        AtFloor = TravelQueue.Peek();
                        TravelQueue.Dequeue();
                        DelayingElevator = -1;
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

        public void ElevatorBehavior(Base @base)
        {
            if (Rider == null)
            {
                GotoFloor();
            }
            SetDelayingElevator(); ;
        }

        public void SendElevatorToRequestedFloor()
        {
            if (DelayingElevator > 0)
            {
                AtFloor = TargetFloor;
                StaffExitsElevator(Rider);
                DelayingElevator = -1;
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
            DelayingElevator = Speed;
        }
    }
}

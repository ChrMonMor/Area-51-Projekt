using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area51ProjektConsoleApp
{
    public class FloorPanel
    {
        public FloorPanel(Elevator elevator)
        {
            Elevator = elevator;
        }
        private static Elevator Elevator { get; set; }
        public bool AccessVerification()
        {
            Elevator.RequstElevatorToGoToo(Elevator.Rider.TargetFloor);
            Controller.SetSecurityInformation(Elevator.Rider, Elevator.AtFloor);
            if  (Controller.SecurityInformation >= Elevator.TargetFloor.SecurityClearance)
            {
                return true;
            }
            return false;
        }
        public void SendElevatorToFloor()
        {
            if (AccessVerification())
            {
                Elevator.SendElevatorToRequestedFloor();
            }
            else
            {
                Elevator.StaffExitsElevator(Elevator.Rider);
            }
        }
    }
}

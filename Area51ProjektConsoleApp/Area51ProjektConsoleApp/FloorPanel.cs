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
        private bool AccessVerification()
        {
            Elevator.RequstElevatorToGoToo(Elevator.GetRider().GetTargetFloor());
            Controller.SetSecurityInformation(Elevator.GetRider(), Elevator.AtFloor);
            if  (Controller.SecurityInformation >= Elevator.GetTargetFloor().GetSecurityClearance())

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
                Elevator.StaffExitsElevator(Elevator.GetRider());
            }
        }
    }
}

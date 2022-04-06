using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area51ProjektConsoleApp
{
    public class Controller
    {
        private static int securityInformation { get; set; }
        public static int SecurityInformation
        {
            get { return securityInformation; }
            set { securityInformation = value; }
        }

        public static void ElevatorRequestProcess(Floor floorTarget)
        {
            securityInformation = Scanner.ScanStaffMember();
            if (FloorPanel.AccessVerification(floorTarget))
            {
                Elevator.AddToTravelList();
            }
        }
    }
}

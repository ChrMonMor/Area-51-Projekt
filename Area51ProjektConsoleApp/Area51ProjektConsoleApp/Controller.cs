using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area51ProjektConsoleApp
{
    public class Controller
    {
        private static int securityInformation;
        public static int SecurityInformation
        {
            get { return securityInformation; }
            set { securityInformation = value; }
        }
        public static void SetSecurityInformation(Staff staff, Floor floor)
        {
            securityInformation = floor.Scanner.StaffMember(staff);
        }

        public static void ElevatorRequestProcess(Staff staff, Floor floor, Elevator elevator)
        {
            SetSecurityInformation(staff, floor);
            if (securityInformation >= staff.AtFloor.SecurityClearance)
            {
                elevator.AddTooTravelQueue(floor);
            }
            else
            {
                TurretOrder(staff, floor);
            }
        }

        private static void TurretOrder(Staff staff, Floor floor)
        {
            if (floor.CeilingTurret.Kill(staff))
            {
                //Show Message
                Console.WriteLine("KIA {0}", staff.Name);
            }
        }
    }
}

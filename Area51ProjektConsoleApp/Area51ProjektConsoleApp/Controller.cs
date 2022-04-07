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

        public static bool ElevatorRequestProcess()
        {
            return true;
        }

        private void TurretOrder(Staff staff, Floor floor)
        {
            if (floor.CeilingTurret.Kill(staff))
            {
                //Show Message
            }
        }
    }
}

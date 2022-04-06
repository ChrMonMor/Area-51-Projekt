using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area51ProjektConsoleApp
{
    public class FloorPanel
    {
        public static bool AccessVerification(Floor floorTarget)
        {
            if  (Controller.SecurityInformation == floorTarget.SecurityClearance)
            {
                return true;
            }
            return false;
        }
    }
}

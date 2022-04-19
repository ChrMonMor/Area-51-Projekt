using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area51ProjektConsoleApp
{
    public class Scanner
    {
        private static Floor FloorScanner;
        
        public Scanner(Floor floor)
        {
            FloorScanner = floor;
        }

        public int StaffMember(Staff staff)
        {
            // incase that the staff can't be found, this might kill them (but that is fine) 
            if (staff.AtFloor != FloorScanner) { return 0; }
            return staff.SecurityClearance;
        }
    }
}

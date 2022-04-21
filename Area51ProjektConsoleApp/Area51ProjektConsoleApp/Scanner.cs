using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area51ProjektConsoleApp
{
    public class Scanner
    {
        private  Floor StaffScanner { get; set; }
        public Scanner(Floor floor)
        {
            this.StaffScanner = floor;
        }

        public int StaffMemberScan(Staff staff)
        {
            // incase that the staff can't be found, this might kill them (but that is fine) 
            if (staff.AtFloor.FloorNumber != StaffScanner.FloorNumber) { return 0; }
            return staff.GetSecurityClearance();
        }
    }
}

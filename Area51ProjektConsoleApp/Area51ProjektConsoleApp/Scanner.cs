using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area51ProjektConsoleApp
{
    public class Scanner
    {
        private static Staff scanningStaff;

        public static Staff ScanningStaff
        {
            get { return scanningStaff; }
            set { scanningStaff = value; }
        }

        public static int ScanStaffMember()
        {
            return ScanningStaff.SecurityClearance;
        }
        public static void StaffMember(Staff staff)
        {
            scanningStaff = staff;
        }
    }
}

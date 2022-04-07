using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area51ProjektConsoleApp
{
    public class Scanner
    {
        private readonly Floor floor;

        public Scanner(Floor floor)
        {
            this.floor = floor;
        }

        public int StaffMember(Staff staff)
        {
            return staff.SecurityClearance;
        }
    }
}

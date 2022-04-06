using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area51ProjektConsoleApp
{
    public class Floor
    {
        public Floor(int securityClearance)
        {
            Scanner = new Scanner();
            SecurityClearance = securityClearance;
            Panel = new Panel();
            CeilingTurret = new Turret();
        }

        public Scanner Scanner { get; set; }
        public int SecurityClearance { get; set; }
        public Panel Panel { get; set; }
        public Turret CeilingTurret { get; set; }
    }
}

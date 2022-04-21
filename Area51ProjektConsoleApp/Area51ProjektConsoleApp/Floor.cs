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
            FloorNumber = securityClearance;
            Scanner = new Scanner(this);
            SecurityClearance = securityClearance;
            Panel = new Panel(this);
            CeilingTurret = new Turret(this);
        }
        public int FloorNumber { get; set; }
        private Scanner Scanner { get; set; }
        private int SecurityClearance { get; set; }
        private Panel Panel { get; set; }
        private Turret CeilingTurret { get; set; }
        public Scanner GetScanner()
        {
            return Scanner;
        }
        public int GetSecurityClearance()
        {
            return SecurityClearance;
        }
        public Panel GetPanel()
        {
            return Panel;
        }
        public Turret GetCeilingTurret()
        {
            return CeilingTurret;
        }
    }
}

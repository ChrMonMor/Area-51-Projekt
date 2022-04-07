using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area51ProjektConsoleApp
{
    public class Turret
    {
        private static Floor CeilingTurret;

        public Turret(Floor ceilingTurret)
        {
            CeilingTurret = ceilingTurret;
        }

        public bool Kill(Staff staff)
        {
            Delaying.DelayTime(1000,1000000);
            if(staff.AtFloor.CeilingTurret.Equals(CeilingTurret))
            {
                staff.Living = false;
            }
            return !staff.Living;
        }
    }
}

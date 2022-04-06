using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area51ProjektConsoleApp
{
    public class Turret
    {
        public static void Kill(Staff staff, Floor floor)
        {
            DelayKill();
            if(staff.AtFloor == floor)
            {
                staff.Living = false;
                KillConfirm(staff);
            }
        }
        private static void DelayKill()
        {
            Task.Delay(RNG.RandomNumberGenerator(1000, 1000000));
        }
        public static bool KillConfirm(Staff staff)
        {
            if(staff.Living == false)
            {
                return true;
            }
            return false;
        }
    }
}

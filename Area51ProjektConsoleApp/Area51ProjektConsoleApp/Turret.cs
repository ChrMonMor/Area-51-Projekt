using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area51ProjektConsoleApp
{
    public class Turret
    {
        private  Floor CeilingTurret { get; set; }
        private List<Staff> KillList { get; set; }
        private bool Loaded { get; set; }

        public Turret(Floor ceilingTurret)
        {
            CeilingTurret = ceilingTurret;
            KillList = new List<Staff>();
            Loaded = true;
        }

        public bool Kill(Staff staff)
        {
            if (KillList.Contains(staff))
            {
                if (staff.AtFloor.FloorNumber.Equals(CeilingTurret.FloorNumber) && Loaded)
                {
                    staff.Living = false;
                    KillList.Remove(staff);
                    Loaded = false;
                }
                else
                {
                    KillList.Remove(staff);
                }
            }
            else
            {
                KillList.Add(staff);
            }
            return !staff.Living;
        }
        public void ReloadingTurret()
        {
            Loaded = true;
        }
    }
}

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
        private int Loaded { get; set; }
        private readonly int MagazineSize = 1;

        public Turret(Floor ceilingTurret)
        {
            CeilingTurret = ceilingTurret;
            KillList = new List<Staff>();
            Loaded = MagazineSize;
        }

        public bool Kill(Staff staff)
        {
            if (KillList.Contains(staff))
            {
                if (staff.AtFloor.FloorNumber.Equals(CeilingTurret.FloorNumber) && Loaded > 0)
                {
                    staff.Living = false;
                    KillList.Remove(staff);
                    Loaded -= 1;
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
            if(Loaded==0)
            Loaded = MagazineSize;
        }
    }
}

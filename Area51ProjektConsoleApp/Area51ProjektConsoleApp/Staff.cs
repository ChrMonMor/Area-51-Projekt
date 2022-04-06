using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area51ProjektConsoleApp
{
    internal class Staff
    {
        public int SecurityClearance { get; set; }
        public Floor AtFloor { get; set; }
        public Floor TargetFloor { get; set; }
        public bool Living { get; set; }
    }
}

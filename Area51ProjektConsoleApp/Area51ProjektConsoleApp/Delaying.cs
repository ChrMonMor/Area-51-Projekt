using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area51ProjektConsoleApp
{
    public class Delaying
    {
        public static void DelayTime(int i)
        {
            Task.Delay(i);
        }
        public static void DelayTime(int i, int j)
        {
            Task.Delay(RNG.RandomNumberGenerator(i, j));
        }
    }
}

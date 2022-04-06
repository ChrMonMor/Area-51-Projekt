using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area51ProjektConsoleApp
{
    public static class RNG
    {
        private static readonly Random RandomNumber = new Random();

        public static int RandomNumberGenerator(int min, int Max)
        {
            return RandomNumber.Next(min, Max+1);
        }
    }
}

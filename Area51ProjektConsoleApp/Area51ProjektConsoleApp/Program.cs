using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Area51ProjektConsoleApp
{
    public class Program
    {
        static void Main()
        {
            Base @base = new Base();
            do
            {
                @base.AllStaffsNames();
                @base.IsAllStaffHappy();
                Console.WriteLine("______________________________");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}

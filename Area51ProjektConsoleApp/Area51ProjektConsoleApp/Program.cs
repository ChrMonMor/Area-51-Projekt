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
                Console.Clear();
                @base.AllStaffsNames();
                @base.IsAllStaffHappy();
                @base.BuildingBase();
                Console.WriteLine("______________________________");
                Console.WriteLine("Press Esc to end Program. Any other key to Continue");
                @base.BaseBehavior();
                Task.Delay(1000).Wait();
            } while (@base.IsAllStaffHappy());
            Console.ReadLine();
        }
        //Console.ReadKey().Key != ConsoleKey.Escape
    }
}

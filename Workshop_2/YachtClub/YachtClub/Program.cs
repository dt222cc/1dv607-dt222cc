using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Workshop 2 - YachtClub";

            controller.RegistryController c = new controller.RegistryController();
            c.DoStartMenu();
        }
    }
}

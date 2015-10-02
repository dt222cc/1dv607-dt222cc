using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.view
{
    class InputView
    {
        public void RenderWindow(string content)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("===================================");
            Console.WriteLine(content);
            Console.WriteLine("===================================\n");
            Console.ResetColor();
        }

        //Might remove this method(no need to input memberid, low prio)
        public int GetIntegerFromUser(string prompt = "")
        {
            Console.Write(prompt);
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch
            {
                return 0; // force invalid memberid 0 if input cannot be parsed as int
            }
        }

        public string GetStringFromUser(string prompt = "")
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public bool DoesUserWantsToQuit()
        {
            Console.Write("Do you want to try again? (y/n)  : ");
            do
            {
                string input = Console.ReadLine().ToLower();
                if (input == "y" || input == "")
                {
                    return false;
                }
                else if (input == "n")
                {
                    return true;
                }
            } while (true);
        }
    }
}

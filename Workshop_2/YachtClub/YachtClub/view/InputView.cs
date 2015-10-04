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
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("===================================");
            Console.WriteLine(content);
            Console.WriteLine("===================================\n");
            Console.ResetColor();
        }

        public void RenderChoices(int min, int max)
        {
            Console.WriteLine("-----------------------------------");
            Console.Write(" Enter menu choice [{0}-{1}] : ", min, max);
        }

        public int GetMenuChoiceFromUser(int min, int max)
        {
            int keyPressed = int.Parse(Console.ReadLine());
            if (keyPressed < min || keyPressed > max)
            {
                throw new ArgumentOutOfRangeException();
            }
            return keyPressed;
        }

        public void DisplayErrorMessage(string errorMessage)
        {
            Console.WriteLine("-----------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" {0}\n", errorMessage);
            Console.ResetColor();
        }


        public bool DoesUserWantsToQuit()
        {
            Console.Write(" Do you want to try again? (y/n)  : ");
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
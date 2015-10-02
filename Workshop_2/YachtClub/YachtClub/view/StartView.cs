using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.view
{
    class StartView: InputView
    {
        // The startmenu has these choices
        public enum Choices
        {
            ExitApplication,
            ListMembersCompact,
            ListMembersVerbose,
            AddMember
        };
        private const string _appName = "Happy YachtClub";

        private const int _maxKey = 3;
        private const int _minKey = 0;

        public void DisplayStartMenu()
        {
            Console.Clear();
            RenderWindow("          " + _appName + "          ");
            
            Console.WriteLine(" 0. Exit                           ");
            Console.WriteLine(" 1. Show members in a compact view ");
            Console.WriteLine(" 2. Show members in a verbose view ");
            Console.WriteLine(" 3. Add a new user                 \n");

            RenderWindow("      Enter menu choice [" + _minKey + "-" + _maxKey + "]      ");
        }
        
        // Get the startmenu choice from user, must be integer and within the allowed parameters
        public Choices GetStartMenuChoice()
        {
            do
            {
                try
                {
                    Console.Write("Input:  ");
                    int keyPressed = int.Parse(Console.ReadLine());

                    if (keyPressed < _minKey || keyPressed > _maxKey)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    switch (keyPressed)
                    {
                        case 0:
                            return Choices.ExitApplication;
                        case 1:
                            return Choices.ListMembersCompact;
                        case 2:
                            return Choices.ListMembersVerbose;
                        case 3:
                            return Choices.AddMember;
                    }
                }
                catch
                {
                    DisplayStartMenu();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Enter a number between {0} and {1}.\n\n", _minKey, _maxKey);
                    Console.ResetColor();
                }
            } while (true);
        }

        public void DisplayRegistration(string errorMessage = "")
        {
            Console.Clear();
            string content = "        Member registration        ";
            RenderWindow(content);

            if (errorMessage != "") {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0}\n", errorMessage);
                Console.ResetColor();
            }
        }

        public void GetByeMessage()
        {
            DisplayStartMenu();
            Console.Write("Goodbye! ");
        }
    }
}

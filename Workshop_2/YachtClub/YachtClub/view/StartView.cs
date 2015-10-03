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
        public enum StartMenuOperation
        {
            ExitApplication,
            ListMembersCompact,
            ListMembersVerbose,
            AddMember
        };

        private const int _maxKey = 3;
        private const int _minKey = 0;

        public void DisplayStartMenu()
        {
            Console.Clear();
            RenderWindow("          Happy YachtClub          ");
            Console.WriteLine(" 0. Exit                           ");
            Console.WriteLine(" 1. Show members in a compact view ");
            Console.WriteLine(" 2. Show members in a verbose view ");
            Console.WriteLine(" 3. Add a new user                 \n");
            RenderChoices(_minKey, _maxKey);
        }
        
        // Get the startmenu choice from user, must be integer and within the allowed parameters
        public StartMenuOperation GetStartMenuChoice()
        {
            do
            {
                try
                {
                    int keyPressed = GetMenuChoiceFromUser(_minKey, _maxKey);
                    switch (keyPressed)
                    {
                        case 0:
                            return StartMenuOperation.ExitApplication;
                        case 1:
                            return StartMenuOperation.ListMembersCompact;
                        case 2:
                            return StartMenuOperation.ListMembersVerbose;
                        case 3:
                            return StartMenuOperation.AddMember;
                    }
                }
                catch
                {
                    DisplayStartMenu();
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

        public void GetByeMessage()
        {
            DisplayStartMenu();
            Console.Write("\n Goodbye! ");
        }
    }
}
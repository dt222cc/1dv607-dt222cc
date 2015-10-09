using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.view
{
    class StartView: BaseView
    {
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
            RenderWindow("         The Happy Pirate          ");
            Console.WriteLine(" 0. Exit                           ");
            Console.WriteLine(" 1. Show members in a compact view ");
            Console.WriteLine(" 2. Show members in a verbose view ");
            Console.WriteLine(" 3. Add a new user                 ");
            Console.WriteLine("-----------------------------------");
        }
        
        // Get the startmenu choice from user, must be integer and within the allowed parameters
        public StartMenuOperation GetStartMenuChoice()
        {
            do
            {
                try
                {
                    RenderChoices(_minKey, _maxKey);
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

        // Could be more simple, just "view"
        public string GetStringFromUser(bool isName)
        {
            string input = "";
            if (isName == true)
            {
                Console.WriteLine(" Member registration\n");
                Console.Write(" Name           : ");
                input = Console.ReadLine();
            }
            else
            {
                Console.Write(" Personal number: ");
                input = Console.ReadLine();
                Console.WriteLine("-----------------------------------");
            }
            return input;
        }

        public void GetByeMessage()
        {
            DisplayStartMenu();
            Console.Write(" Goodbye! ");
        }
    }
}
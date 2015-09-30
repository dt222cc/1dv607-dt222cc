using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.view
{
    class StartView
    {
        // The startmenu has these choices
        public enum Choices
        {
            ExitApplication,
            ListMembersCompact,
            ListMembersVerbose,
            AddMember
        };

        private static int _maxKey = 3;
        private static int _minKey = 0;
        private string _choice;
        private int _keyPressed;

        public void DisplayStartMenu()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("===================================");
            Console.WriteLine("          Happy YachtClub          ");
            Console.WriteLine("===================================\n");
            Console.ResetColor();
            Console.WriteLine(" 0. Exit                           ");
            Console.WriteLine(" 1. Show members in a compact view ");
            Console.WriteLine(" 2. Show members in a verbose view ");
            Console.WriteLine(" 3. Add a new user                 ");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n===================================");
            Console.WriteLine("      Enter menu choice [{0}-{1}]      ", _minKey, _maxKey);
            Console.WriteLine("===================================\n");
            Console.ResetColor();
        }
        
        // Get the startmenu choice from user, must be integer and within the allowed parameters
        public Choices GetStartMenuChoice()
        {
            do
            {
                _choice = Console.ReadLine();

                try
                {
                    _keyPressed = int.Parse(_choice);

                    if (_keyPressed < _minKey || _keyPressed > _maxKey)
                    {
                        throw new Exception();
                    }

                    switch (_keyPressed)
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
                    Console.Write("Enter a number between {0} and {1}.   ", _minKey, _maxKey);
                    Console.ResetColor();
                }

            } while (true);
        }

        public void GetByeMessage()
        {
            DisplayStartMenu();
            Console.Write("Goodbye! ");
        }
    }
}

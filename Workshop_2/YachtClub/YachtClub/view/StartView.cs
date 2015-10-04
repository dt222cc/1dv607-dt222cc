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
            RenderWindow("          Happy YachtClub          ");
            Console.WriteLine(" 0. Exit                           ");
            Console.WriteLine(" 1. Show members in a compact view ");
            Console.WriteLine(" 2. Show members in a verbose view ");
            Console.WriteLine(" 3. Add a new user                 ");
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

        //Might remove this method(no need to input memberid)
        public int GetMemberIdFromUser()
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(" Member registration\n");
            Console.Write(" MemberId       : ");
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch
            {
                return 0;
            }
        }

        public string GetStringFromUser(bool isName)
        {
            if (isName == true)
            {
                Console.Write(" Name           : ");
            }
            else
            {
                Console.Write(" Personal number: ");
            }
            return Console.ReadLine();
        }

        public void GetByeMessage()
        {
            DisplayStartMenu();
            Console.Write("\n\n Goodbye! ");
        }
    }
}
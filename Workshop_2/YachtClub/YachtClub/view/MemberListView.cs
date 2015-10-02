using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.view
{
    class MemberListView: InputView
    {
        public enum Choices
        {
            GoBack,
            ViewMember
        };

        private string _header;
        private int _keyPressed;
        private bool _pickedCompactList;

        private model.MemberList _memberList;

        public MemberListView(model.MemberList memberList)
        {
            _memberList = memberList;
        }

        public void DisplayMemberListView(bool pickedCompactList)
        {
            _pickedCompactList = pickedCompactList;
            if (pickedCompactList == true)
            {
                _header = "            Compact View           ";
            }
            else
            { 
                _header = "            Verbose View           ";
            }

            Console.Clear();
            RenderWindow(_header);
            Console.WriteLine(" 0. Exit                           ");

            if (pickedCompactList == true)
            {
                DisplayCompactList();
            }
            else
            {
                DisplayVerboseList();
            }

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n===================================");
            Console.WriteLine("       Enter memberId to view      ");
            Console.WriteLine("===================================\n");
            Console.ResetColor();
        }

        // TODO: Work on the forloop, retrieving the memberslist from a file (work on format)
        private void DisplayCompactList()
        {
            ////placeholders
            //Console.WriteLine(" 1. Sing Trinh, Boats: 1");
            //Console.WriteLine(" 4. Kaaaaaaa Boo, Boats: 2");
        }

        private void DisplayVerboseList()
        {
            //placeholders
            //Console.WriteLine(" 1. Sing Trinh, 199302271078");
            //Console.WriteLine("   - Canoe, 2 m, 2015-10-01");
            //Console.WriteLine(" 4. Kaaaaaaa Boo, 199302020101");
            //Console.WriteLine("   - Motorsailer, 10 m, 2015-10-02");
            //Console.WriteLine("   - Other, 3 m, 2015-10-03");
        }

        //Loop until a valid input was made, number
        public int GetUserInput()
        {
            do
            {
                try
                {
                    _keyPressed = int.Parse(Console.ReadLine());

                    if (DoesUserWantsToQuit(_keyPressed))
                    {
                        return _keyPressed;
                    }
                    else
                    {
                        if (_memberList.DoesMemberExist(_keyPressed) == true)
                        {
                            throw new Exception();
                        }
                        return _keyPressed;
                    }
                }
                catch
                {
                    DisplayMemberListView(_pickedCompactList);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Enter a valid memberId.   ");
                    Console.ResetColor();
                }
            } while (true);
        }

        private bool DoesUserWantsToQuit(int keyPressed)
        {
            if (keyPressed == 0) {
                return true;
            }
            return false;
        }
    }
}

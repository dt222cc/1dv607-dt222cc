using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.view
{
    class MemberListView: InputView
    {
        private bool _pickedCompactList;

        private model.MemberList _list;

        public MemberListView(model.MemberList memberList)
        {
            _list = memberList;
        }

        public void DisplayMemberListView(bool pickedCompactList)
        {
            Console.Clear();
            _pickedCompactList = pickedCompactList;
            if (pickedCompactList == true)
            {
                RenderWindow("            Compact View           ");
            }
            else
            { 
                RenderWindow("            Verbose View           ");
            }
            Console.WriteLine(" 0    Exit");

            if (pickedCompactList == true)
            {
                Console.WriteLine("-----------------------------------");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" {0,-4} {1,-20} {2,7}", "Id", "Name", "Boats");
                Console.ResetColor();

                foreach (model.Member m in _list.Members)
                {
                    Console.WriteLine(" {0,-4} {1,-20} {2,5}", m.MemberId, m.Name, m.Boats.Count());
                }
            }
            else
            {
                foreach (model.Member m in _list.Members)
                {
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine(" {0,-4} {1,-16} {2,12}", m.MemberId, m.Name, m.PersonalNumber);
                    if (m.Boats.Count() >= 1)
                    {
                        Console.WriteLine("      -----------------------------");
                    }
                    foreach (model.Boat b in m.Boats)
                    {
                        Console.WriteLine("      {0,-12}{1,5}{2,12:d}", b.Type, b.Length + "m", b.RegistrationDate);
                    }
                }

            }
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n===================================");
            Console.WriteLine("       Enter memberId to view      ");
            Console.WriteLine("===================================\n");
            Console.ResetColor();
        }

        //Loop until a valid input was made, number
        public int GetUserInput()
        {
            do
            {
                try
                {
                    Console.Write("Input: ");
                    int keyPressed = int.Parse(Console.ReadLine());

                    if (DoesUserWantsToQuit(keyPressed) == true)
                    {
                        return keyPressed;
                    }
                    else
                    {
                        var result = _list.GetMemberById(keyPressed); //Catch ArgumentException
                        return keyPressed; // memberId
                    }
                }
                catch(ArgumentException ex)
                {
                    DisplayErrorMessage(ex.Message);
                }
                catch
                {
                    DisplayErrorMessage("Enter a valid memberId.");
                }
            } while (true);
        }

        public void DisplayErrorMessage(string message)
        {
            DisplayMemberListView(_pickedCompactList);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("{0}    ", message);
            Console.ResetColor();
        }

        private bool DoesUserWantsToQuit(int keyPressed)
        {
            if (keyPressed == 0)
            {
                return true;
            }
            return false;
        }
    }
}

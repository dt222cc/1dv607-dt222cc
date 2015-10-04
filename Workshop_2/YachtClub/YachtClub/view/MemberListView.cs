using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.view
{
    class MemberListView: BaseView
    {
        private bool _pickedCompactList;

        private model.MemberList _list;

        // Dependent of the MemberList
        public MemberListView(model.MemberList memberList)
        {
            _list = memberList;
        }
        
        // Display either Compact- or Verbose list
        public void DisplayMemberListView(bool pickedCompactList, string message = "Enter memberId to view")
        {
            _pickedCompactList = pickedCompactList;
            if (pickedCompactList == true)
            {
                RenderWindow("            Compact View           ");
            }
            else
            { 
                RenderWindow("            Verbose View           ");
            }
            Console.WriteLine(" 0    Go back");

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
                        Console.WriteLine("      ............................. ");
                    }
                    foreach (model.Boat b in m.Boats)
                    {
                        Console.WriteLine("      {0,-12}{1,5}{2,12:d}", b.Type, b.Length + "m", b.RegistrationDate);
                    }
                }
            }

            Console.WriteLine("-----------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" {0}: ", message);
            Console.ResetColor();
        }

        //Loop until a valid input was made, integer
        public int GetUserInput()
        {
            do
            {
                try
                {
                    int memberId = int.Parse(Console.ReadLine());

                    if (memberId == 0) // does user want quit?
                    {
                        return memberId;
                    }
                    else
                    {
                        if (_list.GetMemberById(memberId) == null) {
                            throw new ArgumentNullException();
                        }
                        else
                        {
                            return memberId;
                        }
                    }
                }
                catch (ArgumentNullException)
                {
                    DisplayMemberListView(_pickedCompactList, "Enter existing memberId");
                }
                catch (FormatException)
                {
                    DisplayMemberListView(_pickedCompactList, "Enter a valid memberId");
                }
            } while (true);
        }

        // When returning from MemberView
        public bool GetLastView()
        {
            return _pickedCompactList;
        }
    }
}
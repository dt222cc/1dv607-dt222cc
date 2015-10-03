using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.view
{
    class MemberView: InputView
    {
        public enum MemberOperation
        {
            GoBack,
            EditMember,
            DeleteMember,
            AddBoat,
            HandleBoats
        };

        private const int _maxKey = 4;
        private const int _minKey = 0;

        private model.Member _member;

        public void DisplayMember(model.Member member)
        {
            _member = member;
            if (_member != null)
            {
                RenderWindow("          Member details           ");
                Console.WriteLine(" MemberId        : {0}", _member.MemberId);
                Console.WriteLine(" Name            : {0}", _member.Name);
                Console.WriteLine(" Personal number : {0}", _member.PersonalNumber);
                Console.WriteLine("-----------------------------------");

                if (_member.Boats.Count() == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Member has no registered boats");
                    Console.ResetColor();
                    Console.WriteLine("-----------------------------------");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" Registered boats");
                    Console.ResetColor();

                    foreach (model.Boat b in _member.Boats)
                    {
                        Console.WriteLine(" .................................");
                        Console.WriteLine(" Type              : {0}", b.Type);
                        Console.WriteLine(" Length            : {0}m", b.Length);
                        Console.WriteLine(" Registration date : {0:d}", b.RegistrationDate);
                    }
                    Console.WriteLine("-----------------------------------");
                }

                Console.WriteLine(" 0. View memberlist");
                Console.WriteLine(" 1. Edit member details");
                Console.WriteLine(" 2. Delete member");
                Console.WriteLine(" 3. Add a new boat");
                Console.WriteLine(" 4. Handle boats");
                RenderChoices(_minKey, _maxKey);
            }
        }

        public MemberOperation GetMemberOperation()
        {
            do
            {
                try
                {
                    int keyPressed = GetMenuChoiceFromUser(_minKey, _maxKey);
                    switch (keyPressed)
                    {
                        case 0:
                            return MemberOperation.GoBack;
                        case 1:
                            return MemberOperation.EditMember;
                        case 2:
                            return MemberOperation.DeleteMember;
                        case 3:
                            return MemberOperation.AddBoat;
                        case 4:
                            return MemberOperation.HandleBoats;
                    }
                }
                catch
                {
                    DisplayMember(_member);
                }
            } while (true);
        }

        public string ChangeName(string errorMessage = "")
        {
            RenderWindow("       Edit member details        ");
            if (errorMessage != "")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0}\n", errorMessage);
                Console.ResetColor();
            }

            Console.Write(" New name: ");
            return Console.ReadLine();
        }
    }
}
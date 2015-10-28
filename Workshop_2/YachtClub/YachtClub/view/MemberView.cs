using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.view
{
    class MemberView: BaseView
    {
        public enum MemberOperation
        {
            GoBack,
            EditMember,
            DeleteMember,
            AddBoat,
            EditBoat,
            DeleteBoat
        };

        private const int _maxKey = 5;
        private const int _minKey = 0;

        public void DisplayMember(model.Member member)
        {
            if (member != null)
            {
                RenderWindow("          Member details           ");
                Console.WriteLine(" MemberId        : {0}", member.MemberId);
                Console.WriteLine(" Name            : {0}", member.Name);
                Console.WriteLine(" Personal number : {0}", member.PersonalNumber);
                Console.WriteLine("-----------------------------------");

                if (member.Boats.Count() == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Member has no registered boats");
                    Console.ResetColor();
                    Console.WriteLine("-----------------------------------");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("    Registered boats");
                    Console.ResetColor();

                    int count = 1;
                    foreach (model.Boat b in member.Boats)
                    {
                        Console.WriteLine("    ..............................");
                        Console.WriteLine(" {0}. Type              : {1}", count++, b.Type);
                        Console.WriteLine("    Length            : {0}m", b.Length);
                        Console.WriteLine("    Registration date : {0:d}", b.RegistrationDate);
                    }
                    Console.WriteLine("-----------------------------------");
                }

                Console.WriteLine(" 0. View memberlist");
                Console.WriteLine(" 1. Edit member details");
                Console.WriteLine(" 2. Delete user");
                Console.WriteLine(" 3. Add a new boat");
                Console.WriteLine(" 4. Edit a boat");
                Console.WriteLine(" 5. Remove a boat");
                Console.WriteLine("-----------------------------------");
            }
        }

        // Get user input return operation
        public MemberOperation GetMemberOperation()
        {
            do
            {
                RenderChoices(_minKey, _maxKey);
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
                        return MemberOperation.EditBoat;
                    case 5:
                        return MemberOperation.DeleteBoat;
                }
            } while (true);
        }

        // Returns the new name for the member
        public string GetNewName()
        {
            Console.Write(" New name: ");
            string newName = Console.ReadLine();
            Console.WriteLine();
            return newName;
        }

        // With some validation to confirm the delete
        public bool ConfirmDelete(model.Member m)
        {
            Console.WriteLine("-----------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" Repeat the memberId to confirm: ");

            try
            {
                int memberId = int.Parse(Console.ReadLine());
                Console.WriteLine("");
                if (memberId == m.MemberId)
                {
                    PressKeyToContinue();
                    return true;
                }
                else
                {
                    Console.WriteLine(" MemberId missmatched!");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\n Invalid ID!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            PressKeyToContinue();
            return false;
        }
    }
}
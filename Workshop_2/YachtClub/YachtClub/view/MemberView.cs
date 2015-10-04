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
            EditBoat,
            DeleteBoat
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
                Console.WriteLine(" 2. Delete user");
                Console.WriteLine(" 3. Add a new boat");
                Console.WriteLine(" 4. Edit a boat");
                Console.WriteLine(" 5. Remove a boat");
            }
        }

        public MemberOperation GetMemberOperation()
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
                }
                catch
                {
                    DisplayMember(_member);
                }
            } while (true);
        }

        public string ChangeName()
        {
            Console.WriteLine("-----------------------------------");
            Console.Write(" New name: ");
            string newName = Console.ReadLine();
            if (newName == "" || newName.Length < 2 || newName.Length > 20) {
                throw new ArgumentException("Name must be atleast 2 characters\n long and maximum of 20 characters");
            }
            return newName;
        }

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

        private void PressKeyToContinue()
        {
            Console.WriteLine("\n Press any key to continue");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
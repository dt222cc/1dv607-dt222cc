using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.view
{
    class MemberView
    {
        public MemberView()
        {

        }

        public void DisplayMember(int memberId)
        {
            //Retrieve member details from member object
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("===================================");
            Console.WriteLine("             MemberView            ");
            Console.WriteLine("===================================\n");
            Console.ResetColor();
        }
    }
}

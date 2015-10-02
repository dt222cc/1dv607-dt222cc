using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.view
{
    class MemberView: InputView
    {
        private model.Member _member;

        public MemberView(model.Member member)
        {
            _member = member;
        }

        public void DisplayMember()
        {
            Console.Clear();
            string content = "          Member details           ";
            RenderWindow(content);

            Console.WriteLine("MemberId        : {0}", _member.MemberId);
            Console.WriteLine("Name            : {0}", _member.Name);
            Console.WriteLine("Personal number : {0}\n", _member.PersonalNumber);
        }
    }
}

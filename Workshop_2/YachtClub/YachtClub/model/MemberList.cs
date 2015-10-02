using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.model
{
    class MemberList
    {
        private List<Member> _members;
        private MemberListDAL m_DAL = new MemberListDAL();

        // return list as readonly
        public IEnumerable<Member> Members
        {
            get
            {
                return _members;
            }
        }

        public MemberList()
        {
            _members = m_DAL.GetAll();
        }

        public void AddMember(Member memberToRegister)
        {
            foreach (Member m in _members)
            {
                if (m.PersonalNumber == memberToRegister.PersonalNumber)
                {
                    throw new ArgumentException("Member already exists.");
                }
            }
            _members.Add(memberToRegister);
            m_DAL.Save();

            Console.WriteLine("Passed Save()");
        }

        public Member GetMemberById(int memberId)
        {
            foreach(Member m in _members)
            {
                if (m.MemberId == memberId)
                {
                    return m;
                }
            }
            return null;
            //throw new ArgumentException("Member does not exists."); // Trying out different ways of error handeling
        }
    }
}

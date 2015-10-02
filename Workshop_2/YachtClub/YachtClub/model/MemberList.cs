using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.model
{
    class MemberList
    {
        private List<Member> _members = new List<Member>();
        private MemberListDAL m_DAL = new MemberListDAL();

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
                    throw new ArgumentException("A member with specified personal number already exists.");
                }
                else if (m.MemberId == memberToRegister.MemberId)
                {
                    throw new ArgumentException("A member with specified memberId already exists.");
                }
            }
            _members.Add(memberToRegister);
            m_DAL.Save();
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
            throw new ArgumentException("Member does not exists.");
        }
    }
}

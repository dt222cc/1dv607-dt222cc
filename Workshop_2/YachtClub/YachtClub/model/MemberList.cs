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
        private MemberListDAL _mDAL = new MemberListDAL();

        public IEnumerable<Member> Members
        {
            get
            {
                return _members;
            }
        }

        public MemberList()
        {
            _members = _mDAL.GetAll();
        }

        public void AddMember(Member memberToRegister)
        {
            foreach (Member m in _members)
            {
                if (m.PersonalNumber == memberToRegister.PersonalNumber)
                {
                    throw new ArgumentException("A member with specified personal number already exists");
                }
                else if (m.MemberId == memberToRegister.MemberId)
                {
                    throw new ArgumentException("A member with specified memberId already exists");
                }
            }
            _members.Add(memberToRegister);
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
        }


        public void DeleteMember(Member memberToDelete)
        {
            try
            {
                foreach (Member m in _members)
                {
                    if (m.MemberId == memberToDelete.MemberId)
                    {
                        _members.Remove(memberToDelete);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void SaveMemberList()
        {
            _mDAL.Save();
        }

        public void UpdateList()
        {
            _members = _mDAL.GetAll();
        }
    }
}
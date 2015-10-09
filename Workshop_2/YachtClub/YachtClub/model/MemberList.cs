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

        // Get all the members and the members' boats from the "textfile"
        public MemberList()
        {
            _members = _mDAL.GetAll();
        }

        // Try to add the member to the register but validates the id and the ssn/pn, before that happens
        public void AddMember(Member memberToRegister)
        {
            foreach (Member m in _members)
            {
                if (m.PersonalNumber == memberToRegister.PersonalNumber)
                {
                    throw new ArgumentException("A member with specified personal number already exists");
                }
            }
            _members.Add(memberToRegister);
        }

        public int GetUniqueMemberId()
        {
            int newId = 0;

            foreach (Member m in _members)
            {
                if (m.MemberId > newId)
                {
                    newId = m.MemberId;
                }
            }
            return newId + 1;
        }

        // Return the member if memberId match or return null if there's a member with the specified id
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

        // Delete the specified member to delete from the memberlist
        public void DeleteMember(Member memberToDelete)
        {
            _members.Remove(memberToDelete);
        }

        // Update memberlist after modifications to the list
        public void SaveMemberList()
        {
            _mDAL.Save();
        }

        // Refresh the list after a modification was made to make sure the memberlistview is sorted by id
        public void UpdateList()
        {
            _members = _mDAL.GetAll();
        }
    }
}
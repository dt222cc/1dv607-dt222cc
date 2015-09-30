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

        public IEnumerable<Member> Members
        {
            get { return _members; }
        }

        public MemberList()
        {
            //TODO: MemberListDAL or MemberDAL
            //Perhaps one file where member have one row each with memberdetails and boats.
            //a special line/row for keeping up with total registrations made which can be used for generating the memberId.
        }

        // Need some list to work with
        public bool MemberExists(int memberId)
        {
            //throw new NotImplementedException();
            if (memberId == 1) {
                return true;
            }
            return false;
        }
    }
}

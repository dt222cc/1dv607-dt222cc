using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace YachtClub.model
{
    class Member
    {
        private int _memberId;
        private string _name;
        private string _personalNumber;
        private List<Boat> _boats = new List<Boat>();

        public int MemberId
        {
            get { return _memberId; }
            set { _memberId = value; }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length < 2)
                {
                    throw new ArgumentException("Name has too few characters, at least 2 characters");
                }
                _name = value;
            }
        }

        // Simplified for faster testing, just need to be between 1 and 12 in length and just numbers
        public string PersonalNumber
        {
            get { return _personalNumber; }
            set
            {
                Match m = Regex.Match(value, @"(\d{2})?(\d{6})-?(\d{4})");
               
                if(m.Success)
                {
                    _personalNumber = m.Groups[2] + "-" + m.Groups[3];
                }
                else
                {
                    throw new ArgumentException("Personal number is not in a valid format [YYMMDD-NNNN]");
                }
            }
        }

        // Way to access a member's boat (Read only, it is that i think)
        public IEnumerable<Boat> Boats
        {
            get { return _boats.AsEnumerable(); }
        }

        // The constructor
        public Member(int memberId, string name, string personalNumber)
        {
            MemberId = memberId;
            Name = name;
            PersonalNumber = personalNumber;
        }

        // Add boat to the member's boatlist, can have similar boat type and size
        public void AddBoat(Boat boatToRegister)
        {
            _boats.Add(boatToRegister);
        }

        // Delete the specified boat from the member's boatlist
        public void DeleteBoat(Boat boatToDelete)
        {
            _boats.Remove(boatToDelete);
        }

        // Change a member's name, probably not the ideal way of doing things (i'm not so experienced)
        public void ChangeName(string newName)
        {
            _name = newName;
        }
    }
}
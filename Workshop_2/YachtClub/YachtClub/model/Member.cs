using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.model
{
    class Member
    {
        private int _memberId;
        private string _name;
        private string _personalNumber;
        private List<Boat> _boats = new List<Boat>();

        // Placeholder, might want to have this made auto, with a persistence counter somewhere
        public int MemberId
        {
            get { return _memberId; }
            set
            {
                if (value <= 0 || value > 9999)
                {
                    throw new ArgumentException("MemberId needs to be 1 or higher");
                }
                _memberId = value;
            }
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
                else if (value.Length > 20)
                {
                    throw new ArgumentException("Name has too many characters, maximum of 20 characters");
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
                if (value.Length <= 12 && value.Length > 0 && System.Text.RegularExpressions.Regex.IsMatch(value, @"^\d+$") == true)
                {
                        _personalNumber = value;
                }
                else
                {
                    throw new ArgumentException("PersonalNumber/BirthDate is not in a valid format");
                }
            }
        }

        public IEnumerable<Boat> Boats
        {
            get { return _boats.AsEnumerable(); }
        }

        public Member(int memberId, string name, string personalNumber)
        {
            MemberId = memberId;
            Name = name;
            PersonalNumber = personalNumber;
        }

        public void AddBoat(Boat boatToRegister)
        {
            foreach (Boat b in _boats)
            {
                if (b.Type == boatToRegister.Type &&
                    b.Length == boatToRegister.Length &&
                    b.RegistrationDate == boatToRegister.RegistrationDate)
                {
                    throw new ArgumentException("Boat is already registered");
                }
            }
            _boats.Add(boatToRegister);
        }

        public void DeleteBoat(Boat boatToDelete)
        {
            try
            {
                foreach (Boat b in _boats)
                {
                    if (b == boatToDelete)
                    {
                        _boats.Remove(boatToDelete);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ChangeName(string newName)
        {
            _name = newName;
        }
    }
}
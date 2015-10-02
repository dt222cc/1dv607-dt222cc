using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.model
{
    // This whole class is not tested yet
    class Boat
    {
        //public enum BoatType
        //{
        //    Sailboat,
        //    Motorsailer,
        //    Canoe,
        //    Other
        //}

        private BoatType _type;
        private double _length;
        private DateTime _registrationDate;

        public BoatType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public double Length
        {
            get { return _length; }
            set
            {
                if (value <= 0 || value > 50)
                {
                    throw new ArgumentException("Boat length needs to be between 0 and 50 m");
                }
                _length = value;
            }
        }
        // Not sure if this works (date), i'll get to it later when working with boats
        public DateTime RegistrationDate
        {
            get { return _registrationDate; }
            set { _registrationDate = value; }
        }

        public Boat(BoatType type, double length, DateTime registrationDate)
        {
            Type = type;
            Length = length;
            RegistrationDate = registrationDate;
        }
    }
}
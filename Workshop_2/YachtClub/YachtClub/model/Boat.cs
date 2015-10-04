using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.model
{
    class Boat
    {
        public enum BoatType
        {
            Sailboat,
            Motorsailer,
            Canoe,
            Other
        }

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
                    throw new ArgumentException("Boat length needs to be between 0 and 50 meters");
                }
                _length = value;
            }
        }
        // Meh, want to remove the time from datetime (.Date)
        public DateTime RegistrationDate
        {
            get { return _registrationDate; }
            set { _registrationDate = value.Date; }
        }

        public Boat(BoatType type, double length, DateTime registrationDate)
        {
            Type = type;
            Length = length;
            RegistrationDate = registrationDate.Date;
        }

        public void ChangeLength(double newLength)
        {
            _length = newLength;
        }
    }
}
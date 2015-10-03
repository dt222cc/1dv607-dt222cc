using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.view
{
    class BoatView: InputView
    {
        // A quick (bad) solution / some kind of loop would be better
        public model.Boat.BoatType GetTypeFromUser()
        {
            Console.WriteLine(" 1. {0}", model.Boat.BoatType.Sailboat);
            Console.WriteLine(" 2. {0}", model.Boat.BoatType.Motorsailer);
            Console.WriteLine(" 3. {0}", model.Boat.BoatType.Canoe);
            Console.WriteLine(" 4. {0}", model.Boat.BoatType.Other);
            Console.Write("\nPick boat category: ");

            string keyPressed = Console.ReadLine();
            if (keyPressed == "1")
            {
                return model.Boat.BoatType.Sailboat;
            }
            else if (keyPressed == "2")
            {
                return model.Boat.BoatType.Motorsailer;
            }
            else if (keyPressed == "3")
            {
                return model.Boat.BoatType.Canoe;
            }
            else if (keyPressed == "4")
            {
                return model.Boat.BoatType.Canoe;
            }
            else
            {
                throw new ArgumentException("Not a valid boat type");
            }
        }

        public double GetLengthFromUser()
        {
            Console.Write("Input boat length in meters: ");
            try
            {
                return double.Parse(Console.ReadLine());
            }
            catch
            {
                return 0;
            }
        }

        public DateTime GetRegistrationDate()
        {
            return DateTime.Now;
        }
    }
}

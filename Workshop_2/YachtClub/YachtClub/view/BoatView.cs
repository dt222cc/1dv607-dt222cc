using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.view
{
    class BoatView: BaseView
    {
        // A quick (bad) solution / some kind of loop would be better (not so experienced with enums yet)
        public model.BoatType GetTypeFromUser()
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(" Boat categories/types");
            Console.WriteLine(" 1. {0}", model.BoatType.Sailboat);
            Console.WriteLine(" 2. {0}", model.BoatType.Motorsailer);
            Console.WriteLine(" 3. {0}", model.BoatType.Canoe);
            Console.WriteLine(" 4. {0}", model.BoatType.Other);
            Console.Write("\n -Pick boat category/type: ");

            string keyPressed = Console.ReadLine();
            if (keyPressed == "1")
            {
                return model.BoatType.Sailboat;
            }
            else if (keyPressed == "2")
            {
                return model.BoatType.Motorsailer;
            }
            else if (keyPressed == "3")
            {
                return model.BoatType.Canoe;
            }
            else if (keyPressed == "4")
            {
                return model.BoatType.Canoe;
            }
            else
            {
                throw new ArgumentException("Not a valid boat type");
            }
        }

        public double GetLengthFromUser()
        {
            Console.Write(" -Input boat length in meters: ");
            try
            {
                return double.Parse(Console.ReadLine());
            }
            catch
            {
                return 0;
            }
        }

        // Return current date to register registrationDate (note: perhaps out of place)
        public DateTime GetRegistrationDate()
        {
            return DateTime.Now;
        }

        // Does user wants to Edit or Delete
        public model.Boat GetBoatToEditOrDelete(model.Member member, string operationInLowercaps)
        {
            try
            {
                Console.WriteLine("-----------------------------------");
                Console.Write(" Enter which boat to {0} ", operationInLowercaps);

                int boatToEdit = int.Parse(Console.ReadLine());
                return member.Boats.ElementAt(boatToEdit - 1); // Index start at -1 for some reason
            }
            catch
            {
                throw new ArgumentException("Invalid input!");
            }
        }

        // Edit boat, length
        public double GetNewLengthFromUser()
        {
            try
            {
                double newLength = GetLengthFromUser();
                if (newLength <= 0 || newLength > 50)
                {
                    throw new Exception();
                }
                Console.WriteLine("-----------------------------------");
                return newLength;
            }
            catch
            {
                throw new ArgumentException("Length must be greater than 0m\n and less or equal to 50m");
            }
        }

        // Confirmation for deleting selected boat
        public bool ConfirmDelete()
        {
            DisplayErrorMessage("Are you sure you want to delete this boat?");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" Press y to remove the boat");
            Console.WriteLine(" Press anything else will cancel the request");
            Console.ResetColor();

            // Using ReadKey for instant input
            var keyPressed = Console.ReadKey();
            if (keyPressed.Key == ConsoleKey.Y)
            {
                return true;
            }
            return false;
        }
    }
}
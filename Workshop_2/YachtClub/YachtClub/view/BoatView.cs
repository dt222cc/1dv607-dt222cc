using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.view
{
    class BoatView: BaseView
    {
        // A quick (bad) solution / some kind of loop would be better
        public model.Boat.BoatType GetTypeFromUser()
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(" Boat categories/types");
            Console.WriteLine(" 1. {0}", model.Boat.BoatType.Sailboat);
            Console.WriteLine(" 2. {0}", model.Boat.BoatType.Motorsailer);
            Console.WriteLine(" 3. {0}", model.Boat.BoatType.Canoe);
            Console.WriteLine(" 4. {0}", model.Boat.BoatType.Other);
            Console.Write("\n -Pick boat category/type: ");

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

        public DateTime GetRegistrationDate()
        {
            return DateTime.Now;
        }

        public model.Boat GetBoatToEdit(model.Member member)
        {
            try
            {
                Console.WriteLine("-----------------------------------");
                Console.Write(" Enter which boat to edit: ");
                return GetBoatByIndex(member);
            }
            catch
            {
                throw new ArgumentException("Invalid input!");
            }
        }

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

        public bool ConfirmDelete()
        {
            DisplayErrorMessage("Are you sure you want to delete this boat?");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" Press y to remove the boat");
            Console.WriteLine(" Press anything else will cancel the request");
            Console.ResetColor();
            
            var keyPressed = Console.ReadKey();
            if (keyPressed.Key == ConsoleKey.Y)
            {
                return true;
            }
            return false;
        }

        public model.Boat GetBoatToDelete(model.Member member)
        {
            try
            {
                Console.WriteLine("-----------------------------------");
                Console.Write(" Enter which boat to delete: ");
                return GetBoatByIndex(member);
            }
            catch
            {
                throw new ArgumentException("Invalid input!");
            }
        }

        private model.Boat GetBoatByIndex(model.Member m)
        {
            try
            {
                int boatToEdit = int.Parse(Console.ReadLine());
                return m.Boats.ElementAt(boatToEdit - 1);
            }
            catch
            {
                throw new Exception(); ;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5_Garage_1.Models
{
    public class Vehicle : IVehicle
    {
        public Vehicle(string registrationNumber, string make, string model, int year, string color, int numberOfWheels, double price)
        {
            RegistrationNumber = registrationNumber;
            Make = make;
            Model = model;
            Year = year;
            Color = color;
            NumberOfWheels = numberOfWheels;
            Price = price;
        }

        public string RegistrationNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public int NumberOfWheels { get; set; }
        public double Price { get; set; }

    }

}

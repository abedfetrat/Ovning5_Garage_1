using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5_Garage_1.Vehicles
{
    public class Car : Vehicle
    {
        public Car(string registrationNumber, string make, string model, int year, string color, int numberOfWheels, double price, string fuelType)
            : base(registrationNumber, make, model, year, color, numberOfWheels, price)
        {
            FuelType = fuelType;
        }

        public string FuelType { get; set; }
        //public int NumberOfDoors { get; set; }
        //public int NumberOfSeats { get; set; }
        //public bool IsConvertible { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} Fuel Type: {FuelType}";
        }
    }
}

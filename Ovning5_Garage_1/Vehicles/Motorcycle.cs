using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5_Garage_1.Vehicles
{
    public class Motorcycle : Vehicle
    {
        public Motorcycle(string registrationNumber, string make, string model, int year, string color, int numberOfWheels, double price, string type)
            : base(VehicleType.Motorcycle, registrationNumber, make, model, year, color, numberOfWheels, price)
        {
            MotorcycleType = type;
        }

        public string MotorcycleType { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}\nMotorcycle Type: {MotorcycleType}";
        }
    }
}

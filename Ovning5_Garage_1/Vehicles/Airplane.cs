using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5_Garage_1.Vehicles
{
    public class Airplane : Vehicle
    {
        public Airplane(string registrationNumber, string make, string model, int year, string color, int numberOfWheels, double price, int numberOfEngines)
            : base(VehicleType.Airplane, registrationNumber, make, model, year, color, numberOfWheels, price)
        {
            NumberOfEngines = numberOfEngines;
        }

        public int NumberOfEngines { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}\nNumber of Engines: {NumberOfEngines}";
        }
    }
}

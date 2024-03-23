using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5_Garage_1.Models
{
    public class Boat : Vehicle
    {
        public Boat(string registrationNumber, string make, string model, int year, string color, int numberOfWheels, double price, string propulsionType)
            : base(registrationNumber, make, model, year, color, numberOfWheels, price)
        {
            PropulsionType = propulsionType;
        }

        public string PropulsionType { get; set; }
    }
}

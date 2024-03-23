using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5_Garage_1.Models
{
    public class Motorcycle : Vehicle
    {
        public Motorcycle(string registrationNumber, string make, string model, int year, string color, int numberOfWheels, double price, string type)
            : base(registrationNumber, make, model, year, color, numberOfWheels, price)
        {
            Type = type;
        }

        public string Type { get; set; }
    }
}

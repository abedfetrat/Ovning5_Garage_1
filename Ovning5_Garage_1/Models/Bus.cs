using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5_Garage_1.Models
{
    public class Bus : Vehicle

    {
        public Bus(string registrationNumber, string make, string model, int year, string color, int numberOfWheels, double price, int passengerCapacity)
            : base(registrationNumber, make, model, year, color, numberOfWheels, price)
        {
            PassengerCapacity = passengerCapacity;
        }

        public int PassengerCapacity { get; set; }
    }
}

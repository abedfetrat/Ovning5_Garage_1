using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5_Garage_1.Models
{
    public interface IVehicle
    {
        string RegistrationNumber { get; set; }
        string Make { get; set; }
        string Model { get; set; }
        int Year { get; set; }
        string Color { get; set; }
        int NumberOfWheels { get; set; }
        double Price { get; set; }
    }
}

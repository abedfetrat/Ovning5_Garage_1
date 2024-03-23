using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5_Garage_1.Vehicles
{
    /// <summary>
    /// Interfacet som Vehicle basklassen måste implementera
    /// </summary>
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

using Ovning5_Garage_1.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5_Garage_1.Garage
{
    public interface IHandler
    {
        public void CreateGarage(string name, uint capacity, bool shouldPopulate);
        
        public string GetGarageName();

        public int GetGarageCapacity();

        public int GetNumberOfVehiclesInGarage();

        public bool ParkVehicle(IVehicle vehicle);

        public bool RemoveVehicleByRegistrationNumber(string registrationNumber);

        public IVehicle[] GetAllVehicles();

        public IVehicle? GetVehicleByRegistrationNumber(string registrationNumber);

        public Dictionary<VehicleType, int> GetVehicleTypes();

        public IVehicle[] GetVehiclesByProperties(Dictionary<string, object> properties);
    }
    
}

using Ovning5_Garage_1.Vehicles;

namespace Ovning5_Garage_1.Garage
{
    public interface IHandler
    {
        public void InitGarage(string name, uint capacity);
        
        public string GetGarageName();

        public int GetGarageCapacity();

        public int GetNumberOfVehiclesInGarage();

        public bool GetHasRoom();

        public bool ParkVehicle(IVehicle vehicle);

        public bool RemoveVehicleByRegistrationNumber(string registrationNumber);

        public IVehicle[] GetAllVehicles();

        public IVehicle? GetVehicleByRegistrationNumber(string registrationNumber);

        public Dictionary<VehicleType, int> GetVehicleTypes();

        public IVehicle[] GetVehiclesByProperties(Dictionary<string, object> properties);
    }
    
}

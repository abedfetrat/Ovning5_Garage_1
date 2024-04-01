using Ovning5_Garage_1.Vehicles;

namespace Ovning5_Garage_1.Garage
{
    public class GarageHandler : IHandler
    {
        private Garage<IVehicle> myGarage;

        public GarageHandler()
        {
            myGarage = GetDefaultGarage();
        }

        private Garage<IVehicle> GetDefaultGarage()
        {
            IVehicle[] vehicles = [
                new Car("KEX587", "Toyota", "Auris", 2009, "Grey", 4, 40000, "Petrol"),
                new Airplane("ABC123", "Boeing", "747", 2022, "White", 6, 10000000, 4),
                new Boat("XYZ456", "SeaRay", "Sundancer", 2023, "Blue", 0, 50000, "Outboard"),
                new Bus("DEF789", "Volvo", "XC60", 2024, "Yellow", 6, 80000, 50),
                new Motorcycle("GHI101", "Honda", "CBR1000RR", 2023, "Red", 2, 15000, "Sport")
           ];

            var garage = new Garage<IVehicle>("Default Garage", 10);

            foreach (var vehicle in vehicles)
            {
                garage.Park(vehicle);
            }

            return garage;
        }

        public void InitGarage(string garageName, uint garageCapacity)
        {
            myGarage = new Garage<IVehicle>(garageName, garageCapacity);
        }

        public string GetGarageName()
        {
            return myGarage.Name;
        }

        public int GetGarageCapacity()
        {
            return (int)myGarage.Capacity;
        }

        public bool GetHasRoom() {
            return myGarage.HasRoom();
        }

        public int GetNumberOfVehiclesInGarage()
        {
            return myGarage.NumUsedSpaces;
        }

        public bool ParkVehicle(IVehicle vehicle)
        {
            return myGarage.Park(vehicle);
        }

        public bool RemoveVehicle(IVehicle vehicle)
        {
            return myGarage.Remove(vehicle);
        }

        public bool RemoveVehicleByRegistrationNumber(string registrationNumber)
        {
            return myGarage.RemoveWithRegistrationNumber(registrationNumber);
        }

        public IVehicle[] GetAllVehicles()
        {
            return [.. myGarage];
        }

        public IVehicle? GetVehicleByRegistrationNumber(string registrationNumber)
        {
           return myGarage.GetVehicleWithRegistrationNumber(registrationNumber);
        }

        public Dictionary<VehicleType, int> GetVehicleTypes()
        {
            return myGarage
                .GroupBy(vehicle => vehicle.Type)
                .ToDictionary(
                    group => group.Key,
                    group => group.Count());
        }

        public IVehicle[] GetVehiclesByProperties(Dictionary<string, object> properties)
        {
            return myGarage.Where(vehicle => Helpers.MatchesProperties(vehicle, properties)).ToArray();
        }
    }
}

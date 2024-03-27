using Ovning5_Garage_1.Vehicles;
using Ovning5_Garage_1;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ovning5_Garage_1.Garage
{
    public class GarageHandler
    {
        private Garage<IVehicle> myGarage;

        public GarageHandler()
        {
            myGarage = new Garage<IVehicle>("Default", 0);
        }

        public void CreateGarage(string garageName, uint garageCapacity, bool shouldPopulateGarage)
        {
            myGarage = new Garage<IVehicle>(garageName, garageCapacity);
            if (shouldPopulateGarage)
            {
                populateGarage();
            }
        }

        private void populateGarage()
        {
            IVehicle[] dummyVehicles = [
                new Car("KEX587", "Toyota", "Auris", 2009, "Grey", 4, 40000, "Petrol"),
                new Airplane("ABC123", "Boeing", "747", 2022, "White", 6, 10000000, 4),
                new Boat("XYZ456", "SeaRay", "Sundancer", 2023, "Blue", 0, 50000, "Outboard"),
                new Bus("DEF789", "Volvo", "XC60", 2024, "Yellow", 6, 80000, 50),
                new Motorcycle("GHI101", "Honda", "CBR1000RR", 2023, "Red", 2, 15000, "Sport")
            ];

            foreach (IVehicle vehicle in dummyVehicles)
            {
                myGarage.Park(vehicle);
            }
        }

        public string GetGarageName()
        {
            return myGarage.Name;
        }

        public int GetGarageCapacity()
        {
            return (int)myGarage.Capacity;
        }

        public int GetNumberOfVehiclesInGarage()
        {
            return myGarage.Count();
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
            IVehicle? vehicle = GetVehicleByRegistrationNumber(registrationNumber);
            return myGarage.Remove(vehicle);
        }

        public IVehicle[] GetAllVehicles()
        {
            return [.. myGarage];
        }

        public IVehicle? GetVehicleByRegistrationNumber(string registrationNumber)
        {
            return myGarage.FirstOrDefault(vehicle =>
                string.Equals(vehicle.RegistrationNumber,
                    registrationNumber,
                    StringComparison.OrdinalIgnoreCase));
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
            return myGarage.Where(vehicle => Utils.MatchesProperties(vehicle, properties)).ToArray();
        }
    }
}

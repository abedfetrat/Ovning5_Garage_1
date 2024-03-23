using Ovning5_Garage_1.Garage;
using Ovning5_Garage_1.Vehicles;

namespace Ovning5_Garage_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car("KEX587", "Toyota", "Auris", 2009, "Grey", 4, 40000, "Petrol");
            Boat boat = new Boat("XYZ456", "SeaRay", "Sundancer", 2023, "Blue", 0, 50000, "Outboard");

            IVehicle[] vehicles = {
                new Vehicle("TEST123", "Test", "Test", 2024, "Black", 10, 1000000),
                car,
                new Airplane("ABC123", "Boeing", "747", 2022, "White", 6, 10000000, 4),
                boat,
                new Bus("DEF789", "Volvo", "XC60", 2024, "Yellow", 6, 80000, 50),
                new Motorcycle("GHI101", "Honda", "CBR1000RR", 2023, "Red", 2, 15000, "Sport")
            };

            Garage<IVehicle> myGarage = new Garage<IVehicle>("My Garage", 10);

            foreach (var vehicle in vehicles)
            {
                myGarage.Park(vehicle);
            }

            Console.WriteLine($"Vehicles in {myGarage.Name} with a capacity of {myGarage.Capacity} vehicles:");

            foreach (var vehicle in myGarage)
            {
                Console.WriteLine(vehicle.ToString());
            }

            bool contains = myGarage.Contains(car);
            Console.WriteLine(contains);

            Garage<Boat> myGarageOfBoats = new Garage<Boat>("My Garage of Boats", 5);
            myGarageOfBoats.Park(boat);
        }
    }
}

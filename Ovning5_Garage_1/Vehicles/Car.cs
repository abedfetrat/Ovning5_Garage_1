namespace Ovning5_Garage_1.Vehicles
{
    public class Car : Vehicle
    {
        public Car(string registrationNumber, string make, string model, int year, string color, int numberOfWheels, double price, string fuelType)
            : base(VehicleType.Car, registrationNumber, make, model, year, color, numberOfWheels, price)
        {
            FuelType = fuelType;
        }

        public string FuelType { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}\nFuel Type: {FuelType}";
        }
    }
}

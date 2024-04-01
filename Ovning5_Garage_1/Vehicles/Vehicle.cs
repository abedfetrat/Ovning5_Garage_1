namespace Ovning5_Garage_1.Vehicles
{
    /// <summary>
    /// Base class that all the Vehicle types derrive from
    /// </summary>
    public class Vehicle : IVehicle
    {
        public Vehicle(VehicleType type, string registrationNumber, string make, string model, int year, string color, int numberOfWheels, double price)
        {
            Type = type;
            RegistrationNumber = registrationNumber;
            Make = make;
            Model = model;
            Year = year;
            Color = color;
            NumberOfWheels = numberOfWheels;
            Price = price;
        }

        public VehicleType Type { get; set; }
        public string RegistrationNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public int NumberOfWheels { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"Vehicle Type: {Type}\nRegistration Number: {RegistrationNumber.ToUpper()}\nMake: {Make}\nModel: {Model}\nYear: {Year}\nColor: {Color}\nNumber of Wheels: {NumberOfWheels}\nPrice: {Price:C}";
        }
    }

}

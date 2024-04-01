namespace Ovning5_Garage_1.Vehicles
{
    public class Boat : Vehicle
    {
        public Boat(string registrationNumber, string make, string model, int year, string color, int numberOfWheels, double price, string propulsionType)
            : base(VehicleType.Boat, registrationNumber, make, model, year, color, numberOfWheels, price)
        {
            PropulsionType = propulsionType;
        }

        public string PropulsionType { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}\nPropulsion Type: {PropulsionType}";
        }
    }
}

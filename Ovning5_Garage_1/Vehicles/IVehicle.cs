namespace Ovning5_Garage_1.Vehicles
{
    /// <summary>
    /// The interface that the Vehicle base class must implement
    /// </summary>
    public interface IVehicle
    {
        VehicleType Type { get; set; }
        string RegistrationNumber { get; set; }
        string Make { get; set; }
        string Model { get; set; }
        int Year { get; set; }
        string Color { get; set; }
        int NumberOfWheels { get; set; }
        double Price { get; set; }
    }
}

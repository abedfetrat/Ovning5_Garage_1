using Ovning5_Garage_1.Garage;
using Ovning5_Garage_1.Vehicles;

namespace Ovning5_Garage_1.Tests
{
    public class GarageTests
    {
        [Fact]
        public void Should_ReturnTrue_IfParked()
        {
            // Arrange
            const string REGISTRATION_NUMBER = "ABC123";
            var vehicle = new Vehicle(VehicleType.Airplane, REGISTRATION_NUMBER, "Boeing", "747", 2022, "White", 6, 10000000);
            var garage = new Garage<IVehicle>("Test", 1);
            garage.Park(vehicle);

            // Act
            bool parked = garage.IsParked(REGISTRATION_NUMBER);

            // Assert
            Assert.True(parked);
        }

        [Fact]
        public void Should_ReturnFalse_IfNotParked()
        {
            // Arrange
            const string REGISTRATION_NUMBER = "ABC123";
            var garage = new Garage<IVehicle>("Test", 1);

            // Act
            bool parked = garage.IsParked(REGISTRATION_NUMBER);

            // Assert
            Assert.False(parked);
        }

        [Fact]
        public void Should_ParkVehicle_IfRoom()
        {
            // Arrange
            var garage = new Garage<IVehicle>("Test", 1);
            var vehicle = new Vehicle(VehicleType.Airplane, "ABC123", "Boeing", "747", 2022, "White", 6, 10000000);

            // Act
            bool parked = garage.Park(vehicle);

            // Assert
            Assert.True(parked);
            Assert.Contains(vehicle, garage);
        }

        [Fact]
        public void Should_RemoveVehicle_IfParked()
        {
            // Arrange
            var garage = new Garage<IVehicle>("Test", 1);
            var vehicle = new Vehicle(VehicleType.Airplane, "ABC123", "Boeing", "747", 2022, "White", 6, 10000000);
            garage.Park(vehicle);

            // Act
            bool removed = garage.Remove(vehicle);

            // Assert
            Assert.True(removed);
            Assert.DoesNotContain(vehicle, garage);
        }

        [Fact]
        public void Should_RemoveVehicleWithRegistrationNumber_IfParked()
        {
            // Arrange
            const string REGISTRATION_NUMBER = "ABC123";
            var garage = new Garage<IVehicle>("Test", 1);
            var vehicle = new Vehicle(VehicleType.Airplane, REGISTRATION_NUMBER, "Boeing", "747", 2022, "White", 6, 10000000);
            garage.Park(vehicle);

            // Act
            bool removed = garage.RemoveWithRegistrationNumber(REGISTRATION_NUMBER);

            // Assert
            Assert.True(removed);
            Assert.DoesNotContain(vehicle, garage);
        }

        [Fact]
        public void Should_ReturnVehicleWithRegistrationNumber_IfParked()
        {
            // Arrange
            const string REGISTRATION_NUMBER = "ABC123";
            var garage = new Garage<IVehicle>("Test", 1);
            var vehicle = new Vehicle(VehicleType.Airplane, REGISTRATION_NUMBER, "Boeing", "747", 2022, "White", 6, 10000000);
            garage.Park(vehicle);

            // Act
            IVehicle? found = garage.GetVehicleWithRegistrationNumber(REGISTRATION_NUMBER);

            // Assert
            Assert.NotNull(found);
            Assert.Equal(REGISTRATION_NUMBER, found.RegistrationNumber);
        }
    }
}
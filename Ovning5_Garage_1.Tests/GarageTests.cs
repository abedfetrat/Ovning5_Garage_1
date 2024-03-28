using Ovning5_Garage_1.Garage;
using Ovning5_Garage_1.Vehicles;

namespace Ovning5_Garage_1.Tests
{
    public class GarageTests
    {
        [Fact]
        public void Park_Should_Park_Vehicle_If_Space()
        {
            // ARRANGE
            uint capacity = 2;
            Garage<IVehicle> myGarage = new Garage<IVehicle>("Test", capacity);
            Airplane vehicle = new Airplane("ABC123", "Boeing", "747", 2022, "White", 6, 10000000, 4);

            // ACT
            bool parked = myGarage.Park(vehicle);

            // ASSERT
            Assert.True(parked);
            Assert.Contains(vehicle, myGarage);
        }

        [Fact]
        public void Remove_Should_Remove_Vehicle()
        {
            // ARRANGE
            uint capacity = 2;
            Garage<IVehicle> myGarage = new Garage<IVehicle>("Test", capacity);
            Motorcycle vehicle = new Motorcycle("GHI101", "Honda", "CBR1000RR", 2023, "Red", 2, 15000, "Sport");
            myGarage.Park(vehicle);

            // ACT
            bool removed = myGarage.Remove(vehicle);

            // ASSERT
            Assert.True(removed);
            Assert.DoesNotContain(vehicle, myGarage);
        }

        [Fact]
        public void RemoveWithRegistrationNumber_Should_Remove_Vehicle()
        {
            // ARRANGE
            uint capacity = 2;
            Garage<IVehicle> myGarage = new Garage<IVehicle>("Test", capacity);
            string registrationNumber = "GHI101";
            Motorcycle vehicle = new Motorcycle(registrationNumber, "Honda", "CBR1000RR", 2023, "Red", 2, 15000, "Sport");
            myGarage.Park(vehicle);

            // ACT
            bool removed = myGarage.RemoveWithRegistrationNumber(registrationNumber);

            // ASSERT
            Assert.True(removed);
            Assert.DoesNotContain(vehicle, myGarage);
        }

        [Fact]
        public void Park_Should_Increase_NumUsedSpaces()
        {
            // ARRANGE
            Garage<IVehicle> myGarage = new Garage<IVehicle>("Test", 2);
            int numUsedSpacesBeforePark = myGarage.NumUsedSpaces;

            // ACT
            myGarage.Park(new Airplane("ABC123", "Boeing", "747", 2022, "White", 6, 10000000, 4));

            // ASSERT
            int numUsedSpacesAfterPark = myGarage.NumUsedSpaces;
            Assert.True(numUsedSpacesAfterPark > numUsedSpacesBeforePark);
        }

        [Fact]
        public void Remove_Should_Decrease_NumUsedSpaces()
        {
            // ARRANGE
            Garage<IVehicle> myGarage = new Garage<IVehicle>("Test", 2);
            myGarage.Park(new Airplane("ABC123", "Boeing", "747", 2022, "White", 6, 10000000, 4));
            int numUsedSpacesBeforeRemove = myGarage.NumUsedSpaces;

            // ACT
            myGarage.RemoveWithRegistrationNumber("ABC123");
            // ASSERT
            int numUsedSpacesAfterRemove = myGarage.NumUsedSpaces;
            Assert.True(numUsedSpacesAfterRemove < numUsedSpacesBeforeRemove);
        }

        [Fact]
        public void IsParked_Should_Return_True_If_Parked()
        {
            // ARRANGE
            Garage<IVehicle> myGarage = new Garage<IVehicle>("Test", 2);
            string registrationNumber = "ABC123";
            myGarage.Park(new Airplane(registrationNumber, "Boeing", "747", 2022, "White", 6, 10000000, 4));

            // ACT
            bool parked = myGarage.IsParked(registrationNumber);

            // ASSERT
            Assert.True(parked);
        }

        [Fact]
        public void IsParked_Should_Return_False_If_NotParked()
        {
            // ARRANGE
            Garage<IVehicle> myGarage = new Garage<IVehicle>("Test", 2);
            string registrationNumber = "ABC123";

            // ACT
            bool parked = myGarage.IsParked(registrationNumber);

            // ASSERT
            Assert.False(parked);
        }

        [Fact]
        public void GetEnumerator_Should_Not_Return_Null_Values()
        {
            // ARRANGE
            Garage<IVehicle> myGarage = new Garage<IVehicle>("Test", 5);
            myGarage.Park(new Airplane("ABC123", "Boeing", "747", 2022, "White", 6, 10000000, 4));

            // ACT
            List<IVehicle> vehicles = [];
            foreach (IVehicle vehicle in myGarage)
            {
                vehicles.Add(vehicle);
            }

            // ASSERT
            Assert.DoesNotContain(null, vehicles);
        }
    }
}
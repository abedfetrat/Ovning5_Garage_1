using Ovning5_Garage_1.Garage;
using Ovning5_Garage_1.UI;
using Ovning5_Garage_1.Vehicles;

namespace Ovning5_Garage_1
{
    public class Manager
    {
        private string title = "Garage Manager";
        private string header = "--------------------------- GARAGE MANAGER ---------------------------";

        private IUI ui;
        private IHandler garageHandler;

        public Manager()
        {
            ui = new ConsoleUI(title, header);
            garageHandler = new GarageHandler();
        }

        public void Start()
        {
            DisplayMainMenu();
        }

        public void Exit()
        {
            Environment.Exit(0);
        }

        private void DisplayMainMenu()
        {
            MenuItem[] items = [
                new("Create a new garage", "1", CreateNewGarage),
                new("Continue with a prepoulated garage", "2", DisplayGarageMenu),
                new("Exit", "Q", Exit)
            ];

            var mainMenu = new Menu("Welcome to Garage Manager", "Navigate by entering the associated key", items);

            ui.DisplayMenu(mainMenu);
        }

        private void DisplayGarageMenu()
        {
            string garageName = garageHandler.GetGarageName();
            int garageCapacity = garageHandler.GetGarageCapacity();
            int numVehiclesInGarage = garageHandler.GetNumberOfVehiclesInGarage();

            string menuTitle = $"Garage: {garageName} ({numVehiclesInGarage}/{garageCapacity} vehicles in garage)";

            MenuItem[] menuItems = [
                new("Add vehicle to garage", "1", AddVehicleToGarage),
                new("Remove vehicle from garage", "2", RemoveVehicleFromGarage),
                new("Display all vehicles", "3", DisplayAllVehiclesInGarage),
                new("Display all vehicle types and count", "4", DisplayAllVehicleTypesInGarage),
                new("Find vehicle by registration number", "5", FindVehicleByRegistrationNumber),
                new("Find vehicle by properties", "6", FindVehiclesByProperties),
                new("Go back to main menu", "9", DisplayMainMenu),
                new("Exit", "Q", Exit)
            ];

            var garageMenu = new Menu(menuTitle, "Navigate by entering the associated key", menuItems);

            ui.DisplayMenu(garageMenu);
        }

        private void CreateNewGarage()
        {
            ui.DisplayHeader("- Create a new garage -");

            string garageName = ui.PromptForText("Enter a garage name");
            uint garageCapacity = (uint)ui.PromptForIntegerNumber("Enter a garage capacity (number > 0)", min: 1);

            garageHandler.InitGarage(garageName, garageCapacity);

            ui.DisplayText("\nYour garage has been created!");

            ui.PromptForAnyKey("\nPress any key to continue...");

            DisplayGarageMenu();
        }

        private void AddVehicleToGarage()
        {
            ui.DisplayHeader("- Add vehicle to garage -");

            string[] vehicleTypes = Enum.GetNames(typeof(VehicleType));

            string type = ui.PromptForOption($"What type of vehicle do you want to park? ({string.Join(", ", vehicleTypes)})", vehicleTypes);
            string regNumber = ui.PromptForText("Registration Number");
            string make = ui.PromptForText("Make");
            string model = ui.PromptForText("Model");
            int year = ui.PromptForIntegerNumber("Year", min: 0);
            string color = ui.PromptForText("Color");
            int numberOfWheels = ui.PromptForIntegerNumber("Number of Wheels", min: 0);
            double price = ui.PromptForDecimalNumber("Price");

            IVehicle? vehicle = null;
            Enum.TryParse(type, true, out VehicleType vehicleType);

            if (vehicleType == VehicleType.Airplane)
            {
                int numberOfEngines = ui.PromptForIntegerNumber("Number of Engines", min: 0);
                vehicle = new Airplane(regNumber, make, model, year, color, numberOfWheels, price, numberOfEngines);
            }
            else if (vehicleType == VehicleType.Boat)
            {
                string propulsionType = ui.PromptForText("Propulsion Type");
                vehicle = new Boat(regNumber, make, model, year, color, numberOfWheels, price, propulsionType);
            }
            else if (vehicleType == VehicleType.Bus)
            {
                int passengerCapacity = ui.PromptForIntegerNumber("Propulsion Type", min: 0);
                vehicle = new Bus(regNumber, make, model, year, color, numberOfWheels, price, passengerCapacity);
            }
            else if (vehicleType == VehicleType.Car)
            {
                string fuelType = ui.PromptForText("Fuel Type");
                vehicle = new Car(regNumber, make, model, year, color, numberOfWheels, price, fuelType);
            }
            else if (vehicleType == VehicleType.Motorcycle)
            {
                string motorcycleType = ui.PromptForText("Motorcycle Type");
                vehicle = new Motorcycle(regNumber, make, model, year, color, numberOfWheels, price, motorcycleType);
            }

            if (vehicle != null)
            {
                bool parked = garageHandler.ParkVehicle(vehicle);
                if (parked)
                {
                    ui.DisplayText("\nThe vehicle was parked in the garage!");
                }
                else
                {
                    bool hasRoom = garageHandler.GetHasRoom();
                    
                    if (hasRoom) {
                        ui.DisplayText("\nCould not park the vehicle. There is already a vehicle with the same registration number parked.");
                    } else {
                        ui.DisplayText("\nCould not park the vehicle. The garage is full.");
                    }
                }
            }

            ui.PromptForAnyKey("\nPress any key to go back to the menu...");

            DisplayGarageMenu();
        }

        private void RemoveVehicleFromGarage()
        {
            ui.DisplayHeader("- Remove vehicle from garage -");

            string regNumber = ui.PromptForText("Enter the registration number of the vehicle you want to remove");

            ui.DisplayHeader("- Remove vehicle from garage -");

            bool removed = garageHandler.RemoveVehicleByRegistrationNumber(regNumber);

            if (removed)
                ui.DisplayText("Vehicle removed from the garage!");
            else
                ui.DisplayText("There are no vehicles with that registration number parked in the garage.");

            ui.PromptForAnyKey("\nPress any key to go back to the menu...");

            DisplayGarageMenu();
        }

        private void DisplayAllVehiclesInGarage()
        {
            ui.DisplayHeader("- All vehicles in the garage -");

            IVehicle[] vehicles = garageHandler.GetAllVehicles();

            ui.ListVehicles(vehicles);

            ui.PromptForAnyKey("Press any key to go back to the menu...");

            DisplayGarageMenu();
        }

        private void DisplayAllVehicleTypesInGarage()
        {
            ui.DisplayHeader("- Types of vehicles in the garage -");

            Dictionary<VehicleType, int> vehicleTypes = garageHandler.GetVehicleTypes();

            foreach (var vehicleType in vehicleTypes)
            {
                string suffix = vehicleType.Value > 1 ?
                (vehicleType.Key == VehicleType.Bus ? "es" : "s") : "";

                ui.DisplayText($"{vehicleType.Value} {vehicleType.Key}{suffix}");
            }

            ui.PromptForAnyKey("\nPress any key to go back to the menu...");

            DisplayGarageMenu();
        }

        private void FindVehicleByRegistrationNumber()
        {
            ui.DisplayHeader("- Find vehicle by registration number -");

            string regNumber = ui.PromptForText("Enter the registration number");

            ui.DisplayHeader("- Find vehicle by registration number -");

            IVehicle? vehicle = garageHandler.GetVehicleByRegistrationNumber(regNumber);

            if (vehicle != null)
                ui.DisplayText($"Found vehicle:\n\n{vehicle}");
            else
                ui.DisplayText("Could not find a vehicle with that registration number");

            ui.PromptForAnyKey("\nPress any key to go back to the menu...");

            DisplayGarageMenu();
        }

        private void FindVehiclesByProperties()
        {
            ui.DisplayHeader("- Find vehicle by properties -");
            ui.DisplayText("Fill in the properties you want to search for. Otherwise leave blank and press enter.\n");

            Dictionary<string, object> filters = [];

            string vehicleType = ui.PromptForText("Vehicle Type (Airplane, Boat, Car, Bus, Motorcycle)", minLength: 0);
            if (!string.IsNullOrWhiteSpace(vehicleType) && Enum.TryParse(vehicleType, true, out VehicleType type))
            {
                filters.Add("Type", type);
            }

            string regNumber = ui.PromptForText("Registration Number", minLength: 0);
            if (!string.IsNullOrWhiteSpace(regNumber))
            {
                filters.Add("RegistrationNumber", regNumber);
            }

            string model = ui.PromptForText("Model", minLength: 0);
            if (!string.IsNullOrWhiteSpace(model))
            {
                filters.Add("Model", model);
            }

            string year = ui.PromptForText("Year", minLength: 0);
            if (!string.IsNullOrWhiteSpace(year) && int.TryParse(year, out int actual))
            {
                filters.Add("Year", actual);
            }

            string color = ui.PromptForText("Color", minLength: 0);
            if (!string.IsNullOrWhiteSpace(color))
            {
                filters.Add("Color", color);
            }

            string numberOfWheels = ui.PromptForText("Number of Wheels", minLength: 0);
            if (!string.IsNullOrWhiteSpace(numberOfWheels) && int.TryParse(numberOfWheels, out int numberOfWheelsValue))
            {
                filters.Add("NumberOfWheels", numberOfWheelsValue);
            }

            string price = ui.PromptForText("Price", minLength: 0);
            if (!string.IsNullOrWhiteSpace(price) && double.TryParse(price, out double priceValue))
            {
                filters.Add("Price", priceValue);
            }

            IVehicle[] vehicles = garageHandler.GetVehiclesByProperties(filters);

            ui.DisplayHeader("- Find vehicle by properties -");

            if (vehicles.Length > 0)
            {
                ui.DisplayText("Vehicles in garage with the specified properties:\n");
                ui.ListVehicles(vehicles);
            }
            else
            {
                ui.DisplayText("There are no vehicles in the garage matching the specified properties\n");
            }

            ui.PromptForAnyKey("Press any key to go back to the menu...");
        }

    }
}

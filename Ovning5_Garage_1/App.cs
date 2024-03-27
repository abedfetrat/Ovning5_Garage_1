using Ovning5_Garage_1.Garage;
using Ovning5_Garage_1.UI;
using Ovning5_Garage_1.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5_Garage_1
{
    public class App
    {
        private string title = "Garage Manager";
        private string header = "--------------------------- GARAGE MANAGER ---------------------------\n";

        private ConsoleUI ui;
        private GarageHandler garageHandler;

        public App()
        {
            ui = new ConsoleUI(title);
            garageHandler = new GarageHandler();
        }

        public void Start()
        {
            StartGarageCreationFlow();
            //garageHandler.CreateGarage("Abed's Garage", 100, true);
            //DisplayMainMenu();
        }

        private void Exit()
        {
            Environment.Exit(0);
        }

        private void StartGarageCreationFlow()
        {
            ui.DisplayText(header);
            ui.DisplayText("First lets create your new garage!\n");

            string garageName = ui.PromptForText("Enter a garage name");
            uint garageCapacity = (uint)ui.PromptForIntegerNumber("Enter a garage capacity (number > 0)", min: 1);
            bool shouldPopulate = ui.PromptForYesOrNoOption("Do you want to populate the garage with some random vehicles? (y/n)");

            garageHandler.CreateGarage(garageName, garageCapacity, shouldPopulate);

            ui.DisplayText("\nYour garage has been created!\n");

            ui.PromptForAnyKey("Press any key to continue...");

            DisplayMainMenu();
        }

        private void DisplayMainMenu()
        {
            ui.Clear();
            ui.DisplayText(header);
            string garageName = garageHandler.GetGarageName();
            int garageCapacity = garageHandler.GetGarageCapacity();
            int numVehiclesInGarage = garageHandler.GetNumberOfVehiclesInGarage();
            ui.DisplayText($"Garage: {garageName} ({numVehiclesInGarage}/{garageCapacity} vehicles in garage)\n");

            ui.DisplayText(
                "What do you want to do?\n" +
                "\n1. Display all vehicles" +
                "\n2. Display all vehicle types and count" +
                "\n3. Find vehicle by registration number" +
                "\n4. Find vehicle by properties" +
                "\n5. Add vehicle to garage" +
                "\n6. Remove vehicle from garage" +
                "\nQ. Quit\n");

            string choice = ui.PromptForText("Enter the number/letter coresponding to the action you want to perform");

            switch (choice)
            {
                case "1":
                    DisplayAllVehiclesInGarage();
                    break;
                case "2":
                    DisplayAllVehicleTypesInGarage();
                    break;
                case "3":
                    FindVehicleByRegistrationNumber();
                    break;
                case "4":
                    FindVehiclesByProperties();
                    break;
                case "5":
                    break;
                case "6":
                    break;
                case "Q":
                case "q":
                    Exit();
                    break;
            }

            DisplayMainMenu();
        }

        private void DisplayAllVehiclesInGarage()
        {
            ui.Clear();
            ui.DisplayText("All vehicles in the garage:\n");

            IVehicle[] vehicles = garageHandler.GetAllVehicles();

            DisplayVehicles(vehicles);

            ui.PromptForAnyKey("Press any key to go back to main menu...");
        }

        private void DisplayAllVehicleTypesInGarage()
        {
            ui.Clear();
            ui.DisplayText("Types of vehicles in the garage:\n");

            Dictionary<VehicleType, int> vehicleTypes = garageHandler.GetVehicleTypes();

            foreach (var vehicleType in vehicleTypes)
            {
                string suffix = vehicleType.Value > 1 ?
                (vehicleType.Key == VehicleType.Bus ? "es" : "s") : "";

                Console.WriteLine($"{vehicleType.Value} {vehicleType.Key}{suffix}");
            }

            ui.PromptForAnyKey("\nPress any key to go back to main menu...");
        }

        private void FindVehicleByRegistrationNumber()
        {
            ui.Clear();

            string regNumber = ui.PromptForText("Enter the registration number");

            IVehicle? vehicle = garageHandler.GetVehicleByRegistrationNumber(regNumber);

            ui.Clear();

            if (vehicle != null)
                ui.DisplayText($"Found vehicle:\n\n{vehicle}");
            else
                ui.DisplayText("Could not find a vehicle with that registration number");

            ui.PromptForAnyKey("\nPress any key to go back to main menu...");
        }

        private void FindVehiclesByProperties()
        {
            ui.Clear();
            ui.DisplayText("Fill in the properties you want to search for. Otherwise leave blank and press enter.\n");

            Dictionary<string, object> filters = [];

            string vehicleType = ui.PromptForText("Vehicle Type (Airplane, Boat, Car, Bus, Motorcycle)");
            if (!string.IsNullOrWhiteSpace(vehicleType) && Enum.TryParse(vehicleType, out VehicleType type))
            {
                filters.Add("Type", type);
            }

            string regNumber = ui.PromptForText("Registration Number");
            if (!string.IsNullOrWhiteSpace(regNumber))
            {
                filters.Add("RegistrationNumber", regNumber);
            }

            string model = ui.PromptForText("Model");
            if (!string.IsNullOrWhiteSpace(model))
            {
                filters.Add("Model", model);
            }

            string year = ui.PromptForText("Year");
            if (!string.IsNullOrWhiteSpace(year) && int.TryParse(year, out int actual))
            {
                filters.Add("Year", actual);
            }

            string color = ui.PromptForText("Color");
            if (!string.IsNullOrWhiteSpace(color))
            {
                filters.Add("Color", color);
            }

            string numberOfWheels = ui.PromptForText("Number of Wheels");
            if (!string.IsNullOrWhiteSpace(numberOfWheels) && int.TryParse(numberOfWheels, out int numberOfWheelsValue))
            {
                filters.Add("NumberOfWheels", numberOfWheelsValue);
            }

            string price = ui.PromptForText("Price");
            if (!string.IsNullOrWhiteSpace(price) && double.TryParse(price, out double priceValue))
            {
                filters.Add("Price", priceValue);
            }

            IVehicle[] vehicles = garageHandler.GetVehiclesByProperties(filters);

            ui.Clear();
            ui.DisplayText("Vehicles in garage with the specified properties:\n");

            DisplayVehicles(vehicles);

            ui.PromptForAnyKey("Press any key to go back to main menu...");
        }

        private void DisplayVehicles(IVehicle[] vehicles)
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                ui.DisplayText($"{i + 1}.\n{vehicles[i]}\n" +
                "\n----------------------------------------\n");
            }
        }
    }
}

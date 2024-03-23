﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5_Garage_1.Vehicles
{
    /// <summary>
    /// Basklassen som alla Vehicle typer ärver från
    /// </summary>
    public class Vehicle : IVehicle
    {
        public Vehicle(string registrationNumber, string make, string model, int year, string color, int numberOfWheels, double price)
        {
            RegistrationNumber = registrationNumber;
            Make = make;
            Model = model;
            Year = year;
            Color = color;
            NumberOfWheels = numberOfWheels;
            Price = price;
        }

        public string RegistrationNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public int NumberOfWheels { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"Registration Number: {RegistrationNumber}, Make: {Make}, Model: {Model}, Year: {Year}, Color: {Color}, Number of Wheels: {NumberOfWheels}, Price: {Price:C}";
        }
    }

}
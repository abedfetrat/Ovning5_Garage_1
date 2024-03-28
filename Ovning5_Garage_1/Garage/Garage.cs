﻿using Ovning5_Garage_1.Vehicles;
using System.Collections;

namespace Ovning5_Garage_1.Garage
{
    /// <summary>
    /// Garage collection that can hold vehicle types that implement IVehicle.
    /// </summary>
    /// <typeparam name="T">A vehicle type that implements IVehicle.</typeparam>
    public class Garage<T> : IEnumerable<T> where T : IVehicle
    {
        private readonly T[] parkingSpaces;

        public Garage(string name, uint capacity)
        {
            Name = name;
            Capacity = capacity;
            parkingSpaces = new T[capacity];
            NumUsedSpaces = 0;
        }

        public string Name { get; set; }
        public uint Capacity { get; }
        public int NumUsedSpaces { get; private set; }

        public bool Park(T vehicle)
        {
            if (IsParked(vehicle.RegistrationNumber)) return false;

            for (int i = 0; i < parkingSpaces.Length; i++)
            {
                if (parkingSpaces[i] == null)
                {
                    parkingSpaces[i] = vehicle;
                    NumUsedSpaces++;
                    return true;
                }
            }

            return false;
        }

        public bool Remove(T vehicle)
        {
            for (int i = 0; i < parkingSpaces.Length; i++)
            {
                if (parkingSpaces[i] != null && parkingSpaces[i].Equals(vehicle))
                {
                    parkingSpaces[i] = default!;
                    NumUsedSpaces--;
                    return true;
                }
            }

            return false;
        }

        public bool RemoveWithRegistrationNumber(string registrationNumber)
        {
            for (int i = 0; i < parkingSpaces.Length; i++)
            {
                IVehicle vehicle = parkingSpaces[i];
                if (vehicle != null && string.Equals(vehicle.RegistrationNumber,
                    registrationNumber,
                    StringComparison.OrdinalIgnoreCase))
                {
                    parkingSpaces[i] = default!;
                    NumUsedSpaces--;
                    return true;
                }
            }

            return false;
        }

        public bool IsParked(string registrationNumber)
        {
            for (int i = 0; i < parkingSpaces.Length; i++)
            {
                IVehicle vehicle = parkingSpaces[i];
                if (vehicle != null && string.Equals(vehicle.RegistrationNumber,
                    registrationNumber,
                    StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }

            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < NumUsedSpaces; i++)
            {
                if (parkingSpaces[i] != null)
                {
                    yield return parkingSpaces[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

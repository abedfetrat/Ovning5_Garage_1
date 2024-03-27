using Ovning5_Garage_1.Vehicles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ovning5_Garage_1.Garage
{
    /// <summary>
    /// Garage klassen, en kollektion som kan innehålla alla typer av Vehicles som implementerat IVehicle interfacet.
    /// </summary>
    /// <typeparam name="T">Vehicle typ som implementerat IVehicle.</typeparam>
    public class Garage<T> : IEnumerable<T> where T : IVehicle
    {
        private T[] parkingSpaces;
        /// Håller koll på antalet använda parkeringsplatser. Används för att undvika att retunera null i GetEnumerator metoden.
        private int count;

        public Garage(string name, uint capacity)
        {
            Name = name;
            Capacity = capacity;
            parkingSpaces = new T[capacity];
            count = 0;
        }

        public string Name { get; set; }
        public uint Capacity { get; }
        /// <summary>
        /// Lägger till fordonet i garaget.
        /// </summary>
        /// <param name="vehicle">En fordon av typen T</param>
        /// <returns><c>true</c> om garaget har utrymme och fordonet kunnat läggas till; annars <c>false</c></returns>
        public bool Park(T vehicle)
        {
            if (count < parkingSpaces.Length && !IsParked(vehicle.RegistrationNumber))
            {
                parkingSpaces[count] = vehicle;
                count++;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Tar bort fordonet från garaget.
        /// </summary>
        /// <param name="vehicle">En fordon av typen T</param>
        /// <returns><c>true</c> om fordonet hittats i garaget och kunnat tas bort; annars <c>false</c></returns>
        public bool Remove(T vehicle)
        {
            for (int i = 0; i < parkingSpaces.Length; i++)
            {
                if (parkingSpaces[i] != null && parkingSpaces[i].Equals(vehicle))
                {
                    ShiftParkingSpacesToLeft(i);
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Flyttar alla fordon i parkingSpaces till början av arrayen. Används vid borttagning av fordon.
        /// På detta sätt undviker vi null värden när garaget itereras.
        /// </summary>
        /// <param name="indexToRemove">Index i parkingSpaces för det element som ska tas bort</param>
        private void ShiftParkingSpacesToLeft(int indexToRemove)
        {
            for (int i = indexToRemove; i < count; i++)
            {
                parkingSpaces[i] = parkingSpaces[i + 1];
            }
            count--;
        }

        private bool IsParked(string registrationNumber)
        {
            bool isParked = false;

            for (int i = 0; i < count; i++)
            {
                IVehicle vehicle = parkingSpaces[i];
                if (vehicle.RegistrationNumber == registrationNumber)
                    isParked = true;
            }

            return isParked;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return parkingSpaces[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

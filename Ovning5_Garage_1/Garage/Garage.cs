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
        // Håller koll på antalet använda parkeringsplatser. Används för att undvika att retunera null i GetEnumerator metoden.
        private int count;

        public Garage(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            parkingSpaces = new T[capacity];
            count = 0;
        }

        public string Name { get; set; }
        public int Capacity { get; }
        /// <summary>
        /// Lägger till fordonet i garaget.
        /// </summary>
        /// <param name="vehicle">En fordon av typen T</param>
        /// <returns><c>true</c> om garaget har utrymme och fordonet kunnat läggas till; annars <c>false</c></returns>
        public bool Park(T vehicle)
        {
            if (count < parkingSpaces.Length)
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
                    parkingSpaces[i] = default(T);
                    return true;
                }
            }
            return false;
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

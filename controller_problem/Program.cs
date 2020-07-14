using System;
using System.Collections.Generic;

namespace list_testings
{

    public class Vehicle
    {
        public string model { get; set; }
        public int id { get; set; }
        public override string ToString()
        {
            return "Model: " + model + "   VehId: " + id;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            vehicles.Add(new Vehicle() { model = "Fiesta", id = 0 });
            vehicles.Add(new Vehicle() { model = "Astra", id = 1 });
            vehicles.Add(new Vehicle() { model = "A3", id = 2 });
            vehicles.Add(new Vehicle() { model = "CLS230", id = 3 });

            foreach (Vehicle veh in vehicles)
            {
                Console.WriteLine(veh);
            }
            
        }
    }
}

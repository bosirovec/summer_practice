using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model.Common;

namespace Project.Model
{
    class Vehicle : IVehicle
    {
        public int Vehicle_id { get; set; }
        public string Model { get; set; }
        public int Kilometers { get; set; }
        public string Color { get; set; }
        public int Owner_id { get; set; }

        public Vehicle(int vehicle_id, string model, int kilometers, string color, int owner_id)
        {
            Vehicle_id = vehicle_id;
            Model = model;
            Kilometers = kilometers;
            Color = color;
            Owner_id = owner_id;
        }
    }
}
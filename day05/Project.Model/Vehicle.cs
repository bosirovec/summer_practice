using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Project.Model.Common;

namespace Project.Model
{
    public class Vehicle : IVehicle
    {
        public int VehicleID { get; set; }
        public string Model { get; set; }
        public int Kilometers { get; set; }
        public string Color { get; set; }
        public int OwnerID { get; set; }

        public Vehicle(int vehicle_id, string model, int kilometers, string color, int owner_id)
        {
            VehicleID = vehicle_id;
            Model = model;
            Kilometers = kilometers;
            Color = color;
            OwnerID = owner_id;
        }

        public Vehicle() { }
    }

    public class VehicleNoID : IVehicleNoID
    {
        public string Model { get; set; }
        public int Kilometers { get; set; }
        public string Color { get; set; }
        public int OwnerID { get; set; }


        public VehicleNoID(string model, int kilometers, string color, int ownerID)
        {
            Model = model;
            Kilometers = kilometers;
            Color = color;
            OwnerID = ownerID;
        }

    }
}

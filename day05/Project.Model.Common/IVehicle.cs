using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model.Common
{
    public interface IVehicle
    {
        int VehicleID {get; set; }
        string Model { get; set; }
        int Kilometers { get; set; }
        string Color { get; set; }
        int OwnerID { get; set; }

    }

    public interface IVehicleNoID
    {
        string Model { get; set; }
        int Kilometers { get; set; }
        string Color { get; set; }
        int OwnerID { get; set; }
    }
}

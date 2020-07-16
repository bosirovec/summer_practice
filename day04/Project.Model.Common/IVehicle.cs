using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model.Common
{
    public interface IVehicle
    {
        int Vehicle_id { get; set; }
        string Model { get; set; }
        int Kilometers { get; set; }
        string Color { get; set; }
        int Owner_id { get; set; }

    }
}

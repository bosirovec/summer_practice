using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model.Common;
using Project.Model;

namespace Project.Repository.Common
{
    public interface IVehicleRepository
    {
        List<Vehicle> GetVehicles();
        bool InsertVehicle(Vehicle vehicle);
        bool Drive(int id, int newMiles);
        bool DeleteVehicle(Vehicle vehicle);
    }
}

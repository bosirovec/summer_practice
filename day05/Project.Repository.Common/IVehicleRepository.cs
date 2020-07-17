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
        Task<List<Vehicle>> GetVehicles();
        Task<bool> InsertVehicle(Vehicle vehicle);
        Task<bool> Drive(int id, int newMiles);
        Task<bool> DeleteVehicle(Vehicle vehicle);
    }
}

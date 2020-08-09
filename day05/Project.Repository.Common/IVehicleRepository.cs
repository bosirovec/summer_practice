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
        Task<List<Vehicle>> GetVehiclesAsync();
        Task<Vehicle> GetVehicleAsync(int id);
        Task<VehicleNoID> InsertVehicleAsync (VehicleNoID vehicle);
        Task<Vehicle> DriveAsync (int id, int newMiles);
        Task<bool> DeleteVehicleAsync(int id);
    }
}

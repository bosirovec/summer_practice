using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model;
using Project.Repository;
using Project.Service.Common;


namespace Project.Service
{
    public interface IVehicleService
    {
        Task<List<Vehicle>> GetVehiclesAsync();
        Task<Vehicle> GetVehicleAsync(int id);
        Task<VehicleNoID> InsertVehicleAsync(VehicleNoID vehicle);
        Task<Vehicle> DriveAsync(int idToBeDriven, int driveLength);
        Task<bool> DeleteVehicleAsync(int id);
    }
}

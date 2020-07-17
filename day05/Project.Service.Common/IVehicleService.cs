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
        Task<List<Vehicle>> GetVehicles();
        Task<bool> InsertVehicle(Vehicle vehicle);
        Task<bool> Drive(int idToBeDriven, int driveLength);
        Task<bool> DeleteVehicle(Vehicle vehicle);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Model.Common;
using Project.Model;
using Project.Repository.Common;
using Project.Repository;
using Project.Service.Common;


namespace Project.Service
{
    public class VehicleService : IVehicleService
    {
        private VehicleRepository repository = new VehicleRepository();


        public async Task<List<Vehicle>> GetVehiclesAsync()
        {
            return await repository.GetVehiclesAsync();
        }


        public async Task<Vehicle> GetVehicleAsync(int id)
        {
            return await repository.GetVehicleAsync(id);
        }
        
        
        public async Task<VehicleNoID> InsertVehicleAsync(VehicleNoID vehicle)
        {
             return await repository.InsertVehicleAsync(vehicle);
        }


        public async Task<Vehicle> DriveAsync(int toBeDriven, int driveLength)
        {
            return await repository.DriveAsync(toBeDriven, driveLength);
        }

        public async Task<bool> DeleteVehicleAsync(int id)
        {
            return await repository.DeleteVehicleAsync(id);
        }


    }
}

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

        public async Task<List<Vehicle>> GetVehicles()
        {
            return await repository.GetVehicles();
        }

        
        
        public async Task<bool> InsertVehicle(Vehicle vehicle)
        {
            var vehList = new List<Vehicle>();
            vehList = await repository.GetVehicles();
            vehicle.Vehicle_id =  vehList.Count() + 2;
            //vehicle.Vehicle_id = repository.GetVehicles().Count() + 2;
            return await repository.InsertVehicle(vehicle);
        }


        public async Task<bool> Drive(int toBeDriven, int driveLength)
        {
            return await repository.Drive(toBeDriven, driveLength);
        }

        public async Task<bool> DeleteVehicle(Vehicle vehicle)
        {
            return await repository.DeleteVehicle(vehicle);
        }


    }
}

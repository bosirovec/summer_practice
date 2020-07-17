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

        public List<Vehicle> GetVehicles()
        {
            return repository.GetVehicles();
        }

        
        
        public bool InsertVehicle(Vehicle vehicle)
        {
            vehicle.Vehicle_id = (repository.GetVehicles().Count() + 2);
            return repository.InsertVehicle(vehicle);
        }


        public bool Drive(int toBeDriven, int driveLength)
        {
            return repository.Drive(toBeDriven, driveLength);
        }

        public bool DeleteVehicle(Vehicle vehicle)
        {
            return repository.DeleteVehicle(vehicle);
        }


    }
}

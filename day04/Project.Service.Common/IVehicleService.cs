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
        List<Vehicle> GetVehicles();
        bool InsertVehicle(Vehicle vehicle);
        bool Drive(int idToBeDriven, int driveLength);
        bool DeleteVehicle(Vehicle vehicle);
    }
}

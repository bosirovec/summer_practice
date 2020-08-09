using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Project.Model;
using Project.Model.Common;
using Project.Repository.Common;

namespace Project.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=day03DB;Integrated Security=True";

        public async Task<List<Vehicle>> GetVehiclesAsync()
        {
            var vehicles = new List<Vehicle>();
            using (var connection = new SqlConnection(VehicleRepository.connectionString))
            {
                SqlCommand command = new SqlCommand("Select * FROM vehicle", connection); ;
                connection.Open();
                SqlDataReader reader = await Task.Run(() => command.ExecuteReader());
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Vehicle vehicle = new Vehicle(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3), reader.GetInt32(4));
                        vehicles.Add(vehicle);
                    }

                    reader.Close();
                }
            }
            return vehicles;
        }



        public async Task<Vehicle> GetVehicleAsync(int id)
        {
            using (var connection = new SqlConnection(VehicleRepository.connectionString))
            {
                SqlCommand command = new SqlCommand("Select * from vehicle where vehicle_id = @id;", connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = await command.ExecuteReaderAsync();
                if (reader.HasRows)
                {
                    reader.Read();
                    Vehicle vehicleToReturn = new Vehicle(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3), reader.GetInt32(4));
                    return vehicleToReturn;
                }
                else
                {
                    connection.Close();
                    return null;
                }
            }
        }
             

        public async Task<VehicleNoID> InsertVehicleAsync(VehicleNoID vehicle)
        {
            using (var connection = new SqlConnection(VehicleRepository.connectionString))
            {
                string sqlCommand = "INSERT INTO vehicle VALUES (default,@model,@kms,@color,@oId);";
                connection.Open();
                SqlCommand command = new SqlCommand(sqlCommand, connection);
                command.Parameters.AddWithValue("@model", vehicle.Model);
                command.Parameters.AddWithValue("@kms", vehicle.Kilometers);
                command.Parameters.AddWithValue("@color", vehicle.Color);
                command.Parameters.AddWithValue("@oId", vehicle.OwnerID);
                await Task.Run(() => command.ExecuteNonQuery());
                return vehicle;
            }
        }
        
        public async Task<Vehicle> DriveAsync(int vehId, int driveLength)
        {
            var vozila = new List<Vehicle>();
            vozila = await GetVehiclesAsync();
            var toBeDriven = new Vehicle();
            foreach (var vozilo in vozila)
            {
                if (vozilo.VehicleID == vehId)
                {
                    toBeDriven = vozilo;
                    break;
                }

            }
            using (var connection = new SqlConnection(VehicleRepository.connectionString))
            {
                string sqlCommand = "UPDATE vehicle SET kilometers = @newKilometers WHERE vehicle_id = @id;";
                connection.Open();
                SqlCommand command = new SqlCommand(sqlCommand, connection);
                int newKilometers = toBeDriven.Kilometers + driveLength;
                command.Parameters.AddWithValue("@newKilometers", newKilometers);
                command.Parameters.AddWithValue("@id", vehId);
                await Task.Run(() => command.ExecuteNonQuery());
                return toBeDriven;
            }
        }

        public async Task<bool> DeleteVehicleAsync(int id)
        {
            using(var connection = new SqlConnection(VehicleRepository.connectionString))
            {
                string sqlCommand = "Delete vehicle WHERE vehicle_id = @id;";
                connection.Open();
                var vehicle = GetVehicleAsync(id);
                SqlCommand command = new SqlCommand(sqlCommand, connection);
                command.Parameters.AddWithValue("@id", id);
                await Task.Run(() => command.ExecuteNonQuery());
                
                return true;
            }
        }
    }
}

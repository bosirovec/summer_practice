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

        public async Task<List<Vehicle>> GetVehicles()
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


        public async Task<bool> InsertVehicle(Vehicle vehicle)
        {
            using (var connection = new SqlConnection(VehicleRepository.connectionString))
            {
                string sqlCommand = "INSERT INTO vehicle VALUES (@id,@model,@kms,@color,@oId);";
                connection.Open();
                SqlCommand command = new SqlCommand(sqlCommand, connection);
                command.Parameters.AddWithValue("@id", vehicle.Vehicle_id);
                command.Parameters.AddWithValue("@model", vehicle.Model);
                command.Parameters.AddWithValue("@kms", vehicle.Kilometers);
                command.Parameters.AddWithValue("@color", vehicle.Color);
                command.Parameters.AddWithValue("@oId", vehicle.Owner_id);
                await Task.Run(() => command.ExecuteNonQuery());
                return true;
            }
        }
        
        public async Task<bool> Drive(int vehId, int driveLength)
        {
            var vozila = new List<Vehicle>();
            vozila = await GetVehicles();
            var toBeDriven = new Vehicle();
            foreach (var vozilo in vozila)
            {
                if (vozilo.Vehicle_id == vehId)
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
                return true;
            }
        }

        public async Task<bool> DeleteVehicle(Vehicle vehicle)
        {
            using(var connection = new SqlConnection(VehicleRepository.connectionString))
            {
                string sqlCommand = "Delete vehicle WHERE vehicle_id = @id;";
                connection.Open();
                SqlCommand command = new SqlCommand(sqlCommand, connection);
                command.Parameters.AddWithValue("@id", vehicle.Vehicle_id);
                await Task.Run(() => command.ExecuteNonQuery());
                return true;

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Project.Model;
using Project.Model.Common;
using Project.Repository.Common;


namespace Project.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=day03DB;Integrated Security=True";

        public async Task<List<Owner>> GetOwnersAsync()
        {
            var owners = new List<Owner>();
            using (var connection = new SqlConnection(OwnerRepository.connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM owner;", connection);
                connection.Open();
                SqlDataReader reader =await Task.Run(() => command.ExecuteReader());
                if (reader.HasRows)
                {
                    while(reader.Read())
                    {
                        Owner owner = new Owner();
                        owner.OwnerID = reader.GetInt32(0);
                        owner.FirstName = reader.GetString(1);
                        owner.LastName = reader.GetString(2);
                        owner.Age = reader.GetInt32(3);
                        owner.Town = reader.GetString(4);
                        owners.Add(owner);
                    }
                }
                reader.Close();
            
            }

            return owners;
        }



        public async Task<Owner> GetOwnerAsync(int id)
        {
            using (var connection = new SqlConnection(OwnerRepository.connectionString))
            {
                SqlCommand command = new SqlCommand("Select * from owner from owner_id = @ID", connection);
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = await command.ExecuteReaderAsync();
                Owner owner = new Owner();
                if (reader.HasRows)
                {
                    reader.Read();
                    owner.OwnerID = reader.GetInt32(0);
                    owner.FirstName = reader.GetString(1);
                    owner.LastName = reader.GetString(2);
                    owner.Age = reader.GetInt32(3);
                    owner.Town = reader.GetString(4);
                    
                }
                return owner;
            }
        }


        public async Task<OwnerNoID> InsertOwnerAsync(OwnerNoID vlasnik)
        {
            using(var connection = new SqlConnection(OwnerRepository.connectionString))
                {
                    string sql = "INSERT INTO owner VALUES (default,@fn,@ln,@age,@town);";
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@fn", vlasnik.FirstName);
                    command.Parameters.AddWithValue("@ln", vlasnik.LastName);
                    command.Parameters.AddWithValue("@age", vlasnik.Age);
                    command.Parameters.AddWithValue("@town", vlasnik.Town);
                    await Task.Run(() => command.ExecuteNonQuery());
                return vlasnik;
            }
            
        }


        public async Task<Owner> UpdateOwnerAsnyc(int inptId, Owner vlasnik)
        {
            using (var connection = new SqlConnection(OwnerRepository.connectionString))
            {
                string sql = "UPDATE owner SET firstname = @fn, lastname = @ln, age=@age, town=@town WHERE owner_id = @id;";
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@fn", vlasnik.FirstName);
                command.Parameters.AddWithValue("@ln", vlasnik.LastName);
                command.Parameters.AddWithValue("@age", vlasnik.Age);
                command.Parameters.AddWithValue("@town", vlasnik.Town);
                command.Parameters.AddWithValue("@id", inptId);
                await Task.Run(() => command.ExecuteNonQuery());
                return vlasnik;
            }
        }


        public async Task<bool> DeleteOwnerAsync(int id)
        {
           
                using (var connection = new SqlConnection(OwnerRepository.connectionString))
                {
                    string sql = "DELETE owner WHERE owner_id = @id;";
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@id", id);
                    await Task.Run(() => command.ExecuteNonQuery());
                return true;
                }
               
        }

    }
}

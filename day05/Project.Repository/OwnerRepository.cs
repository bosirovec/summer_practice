using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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

        public async Task<List<Owner>> GetOwners()
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
                        owner.Owner_id = reader.GetInt32(0);
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


        public async Task<bool> InsertOwner(Owner vlasnik)
        {
            using(var connection = new SqlConnection(OwnerRepository.connectionString))
                {
                    string sql = "INSERT INTO owner VALUES (@id,@fn,@ln,@age,@town);";
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@id", vlasnik.Owner_id);
                    command.Parameters.AddWithValue("@fn", vlasnik.FirstName);
                    command.Parameters.AddWithValue("@ln", vlasnik.LastName);
                    command.Parameters.AddWithValue("@age", vlasnik.Age);
                    command.Parameters.AddWithValue("@town", vlasnik.Town);
                    await Task.Run(() => command.ExecuteNonQuery());
                return true;
            }
            
        }


        public async Task<bool> UpdateOwner(int inptId, Owner vlasnik)
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
                return true;
            }
        }


        public async Task<bool> DeleteOwner(Owner vlasnik)
        {
           
                using (var connection = new SqlConnection(OwnerRepository.connectionString))
                {
                    string sql = "DELETE owner WHERE owner_id = @id;";
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@id", vlasnik.Owner_id);
                    await Task.Run(() => command.ExecuteNonQuery());
                return true;
                }
               
        }

    }
}

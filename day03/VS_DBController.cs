using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Data.Common;

namespace Connecting_to_db.Controllers
{
    public class Person
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Person(string fName, string lName)
        {
            firstName = fName;
            lastName = lName;
        }
    }



    public class VS_DBController : ApiController
    {
        public static SqlConnection _con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=day03DB;Integrated Security=True");
   
        



        [Route("api/getnames")]
        public HttpResponseMessage GetNames()
        {
            var people = new List<Person> {};

            SqlConnection connection = _con;
            using (connection) {
                SqlCommand command = new SqlCommand("SELECT firstName, lastName FROM dbo.Owner;", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        Console.WriteLine("{0}\t{1}", reader.GetString(0), reader.GetString(1));
                        people.Add(new Person(reader.GetString(0), reader.GetString(1)));
                        
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, people);
                }
                else
                {
                    Console.WriteLine("No rows found");
                    return Request.CreateResponse(HttpStatusCode.NotFound, "empty");
                }
                reader.Close();

            }
           
            }






        [Route("api/VehByOwner")]
        public HttpResponseMessage GetVeh([FromUri]int inptId)
        {
            var vozila = new List<string> { };
            SqlConnection connection = _con;
            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT firstName, lastName, Owner.owner_id, model, color FROM dbo.Owner, dbo.Vehicle WHERE Owner.owner_id=Vehicle.owner_id " , connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                      
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", reader.GetString(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3), reader.GetString(4));
                        if (reader.GetInt32(2) == inptId)
                        {
                            vozila.Add(reader.GetString(0));
                            vozila.Add(reader.GetString(1));
                            vozila.Add(reader.GetString(3));
                            vozila.Add(reader.GetString(4));
                            vozila.Add("\n");
                        }
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, vozila);
                }
                else
                {
                    Console.WriteLine("No rows found");
                    return Request.CreateResponse(HttpStatusCode.NotFound, inptId);
                }
                reader.Close();

            }
        }





        [Route("api/insertOwner")]
        public HttpResponseMessage Post([FromUri] int id, [FromUri] string firstName, [FromUri] string lastName, [FromUri] int age, [FromUri] string town)
        {
            SqlConnection connection = _con;
            connection.Open();
            using (var command = new SqlCommand("INSERT INTO OWNER VALUES(@id, @firstName, @lastName, @age, @town)", connection))
            {
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@firstName", firstName);
                command.Parameters.AddWithValue("@lastName", lastName);
                command.Parameters.AddWithValue("@age", age);
                command.Parameters.AddWithValue("@town", town);
                command.ExecuteNonQuery();
                return Request.CreateResponse(HttpStatusCode.OK, "inserted");
            }
        }





        [Route("api/update")]
        public HttpResponseMessage Put([FromUri]int ownerID, [FromUri]int newAge)
        {
            SqlConnection connection = _con;
            connection.Open();

            using (var commmand = new SqlCommand("UPDATE Owner SET age = @newAge WHERE owner_id = @ownerID",connection))
            {
                commmand.Parameters.AddWithValue("@newAge", newAge);
                commmand.Parameters.AddWithValue("@ownerID", ownerID);
                commmand.ExecuteNonQuery();
                return Request.CreateResponse(HttpStatusCode.OK, "Age updated ");
            }
        }





        [Route("api/delete")]
        public HttpResponseMessage Delete([FromUri]int inptId)
        {
            SqlConnection connection = _con;
            connection.Open();
            using (var command = new SqlCommand("DELETE FROM Owner WHERE owner_id = @inptId", connection))
            {
                command.Parameters.AddWithValue("@inptId", inptId);
                command.ExecuteNonQuery();
                return Request.CreateResponse(HttpStatusCode.OK, "deleted");
            }

        }
    }
}

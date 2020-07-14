using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Application1.Controllers
{
    public class Vehicle
    {
        public string model { get; set; }
        public int id { get; set; }
        public override string ToString()
        { return "Model: " + model + "   VehId: " + id; }
    }

    public class TestController : ApiController
    {
        List<Vehicle> vehicles = new List<Vehicle>();

        vehicles.Add(new Vehicle() { model = "Fiesta", id = 0 });
        vehicles.Add(new Vehicle() { model = "Astra", id = 1 });
        vehicles.Add(new Vehicle() { model = "A3", id = 2 });
        vehicles.Add(new Vehicle() { model = "CLS230", id = 3 });

        // GET: api/Test
          public HttpResponseMessage Get()
        { 
        }

        // GET: api/Test/5
        public HttpResponseMessage Get(int id)
        {
           // Vehicle veh = GetVehicleFromDB(id);

            if(veh==null)
                return Request.CreateResponse(HttpStatusCode.NotFound, id);
            else
                return Request.CreateResponse(HttpStatusCode.OK, veh);
        }

        // POST: api/Test
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Test/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Test/5
        public void Delete(int id)
        {
        }
    }

    
}

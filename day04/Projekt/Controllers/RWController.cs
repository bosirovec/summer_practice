using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Project.Model;
using Project.Service;
using Project.Model.Common;
using System.ComponentModel.Design.Serialization;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Projekt.Controllers
{
    public class RWController : ApiController
    {


        private OwnerService ownerService = new OwnerService();
        
        
        
        [Route("api/getOwners")]
        public HttpResponseMessage Get()
        {
         
            return Request.CreateResponse(HttpStatusCode.OK, ownerService.GetOwners());
   
        }

       
        
        [Route("api/InsertOwner")]
        public HttpResponseMessage Post([FromBody]RestOwner input)
        {
            Random rnd = new Random();
            int x = rnd.Next(10,10000);
            Owner vlasnik = new Owner(x, input.FirstName, input.LastName, input.Age, input.Town);
            return Request.CreateResponse(HttpStatusCode.OK, ownerService.InsertOwner(vlasnik));
        }

      
        [Route("api/UpdateOwner")]
        public HttpResponseMessage Put([FromUri] int id, [FromBody]Owner vlasnik)
        {
            return Request.CreateResponse(HttpStatusCode.OK, ownerService.UpdateOwner(id, vlasnik));
        }


        [Route("api/DeleteOwner")]
        public HttpResponseMessage Delete([FromBody]Owner vlasnik)
        {
            return Request.CreateResponse(HttpStatusCode.OK ,ownerService.DeleteOwner(vlasnik));
        }



    }


    public class RestOwner
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public RestOwner(string firstName, string lastName, int age, string town)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Town = town;
        }
        public RestOwner() { }
    }
}

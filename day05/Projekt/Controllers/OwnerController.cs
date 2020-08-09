using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Project.Model;
using Project.Service;
using AutoMapper;
using Project.Model.Common;
using System.ComponentModel.Design.Serialization;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Services.Description;
using System.Threading.Tasks;

namespace Projekt.Controllers
{
    #region controllerClass
    public class OwnerController : ApiController
    {


        private OwnerService ownerService = new OwnerService();
        private IMapper Mapper { get; set; }

             
        
        [Route("api/getOwners")]
        public async Task<HttpResponseMessage> Get()
        {
           return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<List<Owner>, List<OwnerNoID>>(await this.ownerService.GetOwnersAsync()));
        }



        [Route("api/getOwner")]
        public async Task<HttpResponseMessage> GetOwner([FromUri] int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, ownerService.GetOwnerAsync(id));
        }




        [Route("api/InsertOwner")]
        public async Task<HttpResponseMessage> Post([FromBody]OwnerNoID vlasnik)
        {
                       
            return Request.CreateResponse(HttpStatusCode.OK, ownerService.InsertOwnerAsync(vlasnik));
           
            
        }

      
        [Route("api/UpdateOwner")]
        public async Task<HttpResponseMessage> Put([FromUri] int id, [FromBody] Owner vlasnik)
        {
            return Request.CreateResponse(HttpStatusCode.OK, ownerService.UpdateOwnerAsync(id, vlasnik));
        }


        [Route("api/DeleteOwner")]
        public async Task<HttpResponseMessage> Delete([FromUri] int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK ,ownerService.DeleteOwnerAsync(id));
        }



    }

    #endregion controllerClass

}

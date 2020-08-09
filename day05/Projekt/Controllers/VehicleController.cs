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
using System.Drawing;
using System.Threading.Tasks;

namespace Projekt.Controllers
{
    #region controllerClass
    public class VehicleController : ApiController
    {
        private VehicleService service = new VehicleService();
        private IMapper Mapper { get; set; }

        [Route("api/getVehicles")]
        public async Task<HttpResponseMessage> Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, Mapper.Map<List<Vehicle>, List<VehicleNoID>>(await this.service.GetVehiclesAsync()));
        }

        [Route("api/getVehicle")]
        public async Task<HttpResponseMessage> GetVeh([FromUri]int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, service.GetVehicleAsync(id));
        }


        [Route("api/insertVehicle")]
        public async Task<HttpResponseMessage> Post([FromBody] VehicleNoID input)
        { 
            return Request.CreateResponse(HttpStatusCode.OK, service.InsertVehicleAsync(input));
        }


        [Route("api/drive")]
        public async Task<HttpResponseMessage> Put([FromUri] int vehId, [FromUri] int driveLength)
        {
            return Request.CreateResponse(HttpStatusCode.OK, service.DriveAsync(vehId, driveLength));
        }


        [Route("api/deleteVehicle")]
        public async Task<HttpResponseMessage> Delete([FromUri]int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, service.DeleteVehicleAsync(id));
        }

    }

    #endregion controllerClass

 }

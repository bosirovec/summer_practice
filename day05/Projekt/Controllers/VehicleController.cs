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


        [Route("api/getVehicles")]
        public async Task<HttpResponseMessage> Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, service.GetVehicles());
        }



        [Route("api/insertVehicle")]
        public async Task<HttpResponseMessage> Post([FromBody] RestVehicle input)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RestVehicle, Project.Model.Vehicle>());
            var mapper = new Mapper(config);
            Project.Model.Vehicle vehicle = mapper.Map<Project.Model.Vehicle>(input);
       
            return Request.CreateResponse(HttpStatusCode.OK, service.InsertVehicle(vehicle));
       }


        [Route("api/drive")]
        public async Task<HttpResponseMessage> Put([FromUri] int vehId, [FromUri] int driveLength)
        {
            return Request.CreateResponse(HttpStatusCode.OK, service.Drive(vehId, driveLength));
        }


        [Route("api/deleteVehicle")]
        public async Task<HttpResponseMessage> Delete([FromBody]Vehicle vehicle)
        {
            return Request.CreateResponse(HttpStatusCode.OK, service.DeleteVehicle(vehicle));
        }

    }

    #endregion controllerClass

    #region restClass
    public class RestVehicle
    {
        public string Model { get; set; }
        public int Kilometers { get; set; }
        public string Color { get; set; }
        public int Owner_Id { get; set; }

        public RestVehicle(string model, int kms, string color, int owner_id)
        {
            Model = model;
            Kilometers = kms;
            Color = color;
            Owner_Id = owner_id;
        }

        public RestVehicle() { }
    }
    #endregion restClass
}

﻿using System;
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

namespace Projekt.Controllers
{
    #region controllerClass
    public class OwnerController : ApiController
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
            var config = new MapperConfiguration(cfg => cfg.CreateMap<RestOwner, Project.Model.Owner>());
            var mapper = new Mapper(config);
            Project.Model.Owner vlasnik = mapper.Map<Project.Model.Owner>(input);
            if (ownerService.InsertOwner(vlasnik))
            {
                return Request.CreateResponse(HttpStatusCode.OK, ownerService.InsertOwner(vlasnik));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            
        }

      
        [Route("api/UpdateOwner")]
        public HttpResponseMessage Put([FromUri] int id, [FromBody] Owner vlasnik)
        {
            return Request.CreateResponse(HttpStatusCode.OK, ownerService.UpdateOwner(id, vlasnik));
        }


        [Route("api/DeleteOwner")]
        public HttpResponseMessage Delete([FromBody] Project.Model.Owner vlasnik)
        {
            return Request.CreateResponse(HttpStatusCode.OK ,ownerService.DeleteOwner(vlasnik));
        }



    }

    #endregion controllerClass

    #region restClass
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
    #endregion restClass
}

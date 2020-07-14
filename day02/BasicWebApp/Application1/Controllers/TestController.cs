﻿using System;
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
        public Vehicle(string inptModel, int inptId) { model = inptModel; id = inptId; }
    }

    public class TestController : ApiController
    {

       static public List<Vehicle> vehicles = new List<Vehicle>() { new Vehicle("Fiesta", 0), new Vehicle("Astra", 1), new Vehicle("A3", 2), new Vehicle("CLS230", 3) };


        //READ all method
        [Route("api/getall")]
        public HttpResponseMessage Get()
        {
            if (vehicles.Count() > 0)
                return Request.CreateResponse(HttpStatusCode.OK, vehicles);
            else
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,"List is empty");
        }




        //READ by ID method
        [Route("api/checkid")]
        public HttpResponseMessage GetID([FromUri]int input)
        {
           foreach(Vehicle veh in vehicles)
            {
                if (veh.id == input)
                    return Request.CreateResponse(HttpStatusCode.OK, veh.model);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, input);
        }



        //CREATE method
        [Route("api/add")]
        public HttpResponseMessage Post([FromBody]Vehicle v)
        {
            vehicles.Add(new Vehicle(v.model, v.id));
            return Request.CreateResponse(HttpStatusCode.OK, vehicles[vehicles.Count() - 1]);
        }





       //UPDATE method
       [Route("api/change")]
        public HttpResponseMessage PutID([FromUri] int i, [FromUri]int j)
        {
            foreach(Vehicle v in vehicles)
            {
                if(v.id == i)
                {
                    v.id = j;
                    return Request.CreateResponse(HttpStatusCode.OK, "Switched id on: " + v.model + " from: "  + i + " to: "+ j);
                }
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }



        //DELETE method
        [Route("api/delete")]
        public IHttpActionResult Delete([FromUri] int input)
        {
            if (input < 0)
                return BadRequest();
            foreach(Vehicle v in vehicles)
            {
                if(v.id == input)
                { vehicles.Remove(v);
                    return Ok("Vehicle with the following id has been removed: " + v.id);
                }
            }
            return NotFound();
        }
    }

    
}
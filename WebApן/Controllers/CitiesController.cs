using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.App_Start
{
    public class CitiesController : ApiController
    {
        [HttpGet]
        [Route("api/Cities/GetListCities")]
        public List<DistanceServer.Cities2> GetListCities()
        {
            return DistanceServer.Cities.GetListCities();
        }


    }
}



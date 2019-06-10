using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class SearchController : ApiController
    {
        [HttpGet]
        [Route("api/Search/GetPopularSearchs")]
        public List<DistanceServer.Classes.Search2> GetPopularSearchs()
        {
            return DistanceServer.Search.GetPopularSearches();
        }


        [HttpPost]
        [Route("api/Search/PostSearch")]
        public IHttpActionResult PostSearch([FromBody]JObject obj)
        {
            double kilometer;
            int source = obj["source"].ToObject<int>();
            int destination = obj["destination"].ToObject<int>();
            bool exist = DistanceServer.Search.CheckIfExistSearch(source, destination);
            if (exist)
            {
                 kilometer = DistanceServer.Search.Update(source, destination);
            }
            else
            {
                kilometer = getDistance(DistanceServer.Cities.GetNameCity(source), DistanceServer.Cities.GetNameCity(destination));
                DistanceServer.Search.AddSearch(source, destination, kilometer);
            }


            return Ok(kilometer);

        }
        [HttpGet]
        [Route("api/Search/GetPopularSearch")]
        public DistanceServer.Classes.Search2 GetPopularSearch()
        {
            return DistanceServer.Search.GetPopularSearch();
        }
        public static int getDistance(string origin, string destination)
        {
            System.Threading.Thread.Sleep(1000);
            int distance = 0;
            string url = "https://maps.googleapis.com/maps/api/distancematrix/json?units=imperial&origins=" + origin + "&destinations=" + destination + " &key=AIzaSyApFoLObeX8OWBCaaaF8xsgKsv5LPuFViU";
            string requesturl = url;
            string content = DistanceServer.GetDistance.fileGetContents(requesturl);
            JObject o = JObject.Parse(content);
            try
            {
                distance = (int)o.SelectToken("rows[0].elements[0].distance.value");
                return distance / 1000;
            }
            catch
            {
                return distance;
            }
        }
      
    }
}

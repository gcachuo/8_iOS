using System;
using PortableLibrary_8iOs.Foursquareclient.DataAccess.Model;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using PortableLibrary_8iOs.Foursquareclient.DataAccess;
using PortableLibrary_8iOs.Foursquareclient;
using System.Linq;
using PortableLibrary_8iOs.Foursquareclient.Entities;
using System.Collections.Generic;

namespace PortableLibrary_8iOs
{
    public class VenueDAOWSImple : IVenueDAO
    {
        private string url;
        public VenueDAOWSImple()
        {
            url = Resources.URL_EXPLORE_VENUES + $"?{Resources.OAUTH_TOKEN.Key}={Resources.OAUTH_TOKEN.Value}&{Resources.V.Key}={Resources.V.Value}";
        }
        public List<VenueDTO> Explore(int limit, double lat, double lng)
        {
            FoursquareResponse response;
            var httpResponse = HttpHandler.GetHttpResponse(url + $"&limit={limit}&ll={lat},{lng}").Result;
            var httpResponseContent = httpResponse.Content.ReadAsStringAsync().Result;
            response = JsonConvert.DeserializeObject<FoursquareResponse>(httpResponseContent);
            return (from v in response.Response.Groups[0].Items select new VenueDTO { Name = v.Venue.Name }).ToList();
        }

        public List<VenueDTO> Explore(int limit, string query, double lat, double lng)
        {
            FoursquareResponse response;
            var httpResponse = HttpHandler.GetHttpResponse(url + $"&limit={limit}&ll={lat},{lng}&query={query}").Result;
            var httpResponseContent = httpResponse.Content.ReadAsStringAsync().Result;
            response = JsonConvert.DeserializeObject<FoursquareResponse>(httpResponseContent);
            return (from v in response.Response.Groups[0].Items select new VenueDTO { Name = v.Venue.Name }).ToList();
        }
    }
}


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
using FoursquareClient;

namespace PortableLibrary_8iOs
{
	public class VenueDAOWSImple : IVenueDAO
	{
		private string url;

		public VenueDAOWSImple ()
		{
			url = Resources.URL_EXPLORE_VENUES +$"?{Resources.OAUTH_TOKEN.Key}={Resources.OAUTH_TOKEN.Value}&{Resources.V.Key}={Resources.V.Value}";
		}

		public List<VenueDTO> Explore (int limit, double lat, double lng)
		{
			FoursquareResponse response;
			var httpResponse = HttpHandler.GetHttpResponse (url +$"&limit={limit}&ll={lat},{lng}");
			var httpResponseContent = httpResponse.Content.ReadAsStringAsync ().Result;
			response = JsonConvert.DeserializeObject<FoursquareResponse> (httpResponseContent);
			var venues = new List<VenueDTO> ();
			foreach (var v in response.Response.Groups[0].Items) {
				var venueDTO = new VenueDTO { Name = v.Venue.Name,
					Lat = v.Venue.Location.Lat,
					Lng = v.Venue.Location.Lng,
					Phone = v.Venue.Contact.FormattedPhone,
					Rating = v.Venue.Rating,
					Address = v.Venue.Location.Address,
					Country = v.Venue.Location.Country,
					State = v.Venue.Location.State,
					City = v.Venue.Location.City,
				};
				foreach (var t in v.Tips) {
					var userDTO = new UserDTO {
						Name = t.User.FirstName + " " + t.User.LastName,
						Photo = t.User.Photo.Prefix +Resources.SIZE_IMAGE_USER +t.User.Photo.Suffix
					};
					venueDTO.Comments.Add (new CommentDTO{ User = userDTO, Text = t.Text });
				}
				venues.Add (venueDTO);
			}
			return venues;
		}

		public List<VenueDTO> Explore (int limit, string query, double lat, double lng)
		{
			FoursquareResponse response;
			var httpResponse = HttpHandler.GetHttpResponse (url +$"&limit={limit}&ll={lat},{lng}&query={query}");
			var httpResponseContent = httpResponse.Content.ReadAsStringAsync ().Result;
			response = JsonConvert.DeserializeObject<FoursquareResponse> (httpResponseContent);
			var venues = new List<VenueDTO> ();
			foreach (var v in response.Response.Groups[0].Items) {
				var venueDTO = new VenueDTO { Name = v.Venue.Name,
					Lat = v.Venue.Location.Lat,
					Lng = v.Venue.Location.Lng,
					Phone = v.Venue.Contact.FormattedPhone,
					Rating = v.Venue.Rating,
					Address = v.Venue.Location.Address,
					Country = v.Venue.Location.Country,
					State = v.Venue.Location.State,
					City = v.Venue.Location.City,
				};
				foreach (var t in v.Tips) {
					var userDTO = new UserDTO {
						Name = t.User.FirstName + " " + t.User.LastName,
						Photo = t.User.Photo.Prefix +Resources.SIZE_IMAGE_USER +t.User.Photo.Suffix
					};
					venueDTO.Comments.Add (new CommentDTO{ User = userDTO, Text = t.Text });
				}
				venues.Add (venueDTO);
			}
			return venues;
		}
	}
}
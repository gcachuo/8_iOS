using PortableLibrary_8iOs.Foursquareclient.DataAccess.Model;
using PortableLibrary_8iOs.Foursquareclient.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortableLibrary_8iOs
{
	public interface IVenueDAO
	{
        List<VenueDTO> Explore(int limit, string query, double lat, double lng);
        List<VenueDTO> Explore(int limit, double lat, double lng);
    }
}


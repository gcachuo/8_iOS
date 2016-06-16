using PortableLibrary_8iOs.Foursquareclient.Entities;
using System;
using System.Collections.Generic;

namespace PortableLibrary_8iOs
{
	public interface IVenueBLO
	{
        List<VenueDTO> Explore(int limit, string query, double lat, double lng);
        List<VenueDTO> Explore(int limit, double lat, double lng);
    }
}


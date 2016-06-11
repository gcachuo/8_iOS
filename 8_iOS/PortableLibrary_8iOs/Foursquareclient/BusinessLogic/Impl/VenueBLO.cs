using System;
using System.Collections.Generic;
using PortableLibrary_8iOs.Foursquareclient.Entities;

namespace PortableLibrary_8iOs
{
    public class VenueBLO : IVenueBLO
    {
        private IVenueDAO venueDAO;
        public VenueBLO(IVenueDAO venueDAO)
        {
            this.venueDAO = venueDAO;
        }

        public List<VenueDTO> Explore(int limit, double lat, double lng)
        {
            return venueDAO.Explore(limit, lat, lng);
        }

        public List<VenueDTO> Explore(int limit, string query, double lat, double lng)
        {
            return venueDAO.Explore(limit, query,lat, lng);
        }
    }
}


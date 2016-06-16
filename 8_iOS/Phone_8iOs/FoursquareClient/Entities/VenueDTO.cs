using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoursquareClient;
using SQLite;

namespace PortableLibrary_8iOs.Foursquareclient.Entities
{
    public class VenueDTO
    {
		[PrimaryKey]
        public string Name { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public string Phone { get; set; }
        public float Rating { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
		[Ignore]
		public List<CommentDTO> Comments {
			get;
			set;
		}= new List<CommentDTO>();
    }
}
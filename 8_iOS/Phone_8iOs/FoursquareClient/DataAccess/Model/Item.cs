using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoursquareClient;

namespace PortableLibrary_8iOs.Foursquareclient.DataAccess.Model
{
    public class Item
    {
        [JsonProperty(PropertyName = "venue")]
        public Venue Venue { get; set; }

		[JsonProperty(PropertyName = "tips")]
		public Tip[] Tips {
			get;
			set;
		}
    }
}

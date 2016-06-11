using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortableLibrary_8iOs.Foursquareclient.DataAccess.Model
{
    public class Contact
    {
        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }

        [JsonProperty(PropertyName = "formattedPhone")]
        public string FormattedPhone { get; set; }
    }
}

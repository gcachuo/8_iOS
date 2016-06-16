using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortableLibrary_8iOs.Foursquareclient.DataAccess.Model
{
    public class FoursquareResponse
    {
        [JsonProperty(PropertyName = "response")]
        public Response Response { get; set; }
    }
}

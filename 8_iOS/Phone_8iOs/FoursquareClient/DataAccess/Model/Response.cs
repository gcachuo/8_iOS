using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortableLibrary_8iOs.Foursquareclient.DataAccess.Model
{
    public class Response
    {
        [JsonProperty(PropertyName = "groups")]
        public Group[] Groups { get; set; }
    }
}

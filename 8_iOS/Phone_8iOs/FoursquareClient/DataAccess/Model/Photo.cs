using System;
using Newtonsoft.Json;

namespace FoursquareClient
{
	public class Photo
	{
		public Photo ()
		{
		}
		[JsonProperty(PropertyName = "prefix")]
		public string Prefix {
			get;
			set;
		}

		[JsonProperty(PropertyName = "suffix")]
		public string Suffix {
			get;
			set;
		}
	}
}


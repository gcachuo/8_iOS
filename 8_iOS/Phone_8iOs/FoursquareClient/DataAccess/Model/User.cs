using System;
using Newtonsoft.Json;

namespace FoursquareClient
{
	public class User
	{
		public User ()
		{
		}
		[JsonProperty(PropertyName = "firstName")]
		public string FirstName {
			get;
			set;
		}

		[JsonProperty(PropertyName = "lastName")]
		public string LastName {
			get;
			set;
		}

		[JsonProperty(PropertyName = "photo")]
		public Photo Photo {
			get;
			set;
		}
	}
}


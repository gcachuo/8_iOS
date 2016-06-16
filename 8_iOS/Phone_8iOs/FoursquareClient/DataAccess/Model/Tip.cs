using System;
using Newtonsoft.Json;

namespace FoursquareClient
{
	public class Tip
	{
		public Tip ()
		{
		}

		[JsonProperty(PropertyName = "text")]
		public string Text {
			get;
			set;
		}

		[JsonProperty(PropertyName = "user")]
		public User User {
			get;
			set;
		}
	}
}


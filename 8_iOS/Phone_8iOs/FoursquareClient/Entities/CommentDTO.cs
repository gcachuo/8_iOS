using System;

namespace FoursquareClient
{
	public class CommentDTO
	{
		public CommentDTO ()
		{
		}
		public string Text {
			get;
			set;
		}
		public UserDTO User {
			get;
			set;
		}
	}
}


using System;

using UIKit;

namespace Phone_8iOs
{
	public partial class vc_Login : UIViewController
	{
		partial void BtnLogin_TouchUpInside(UIButton sender)
		{
			var dvc = new vc_Main();
			NavigationController.PushViewController(dvc, true);
		}



		public vc_Login() : base("vc_Login", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

	}
}



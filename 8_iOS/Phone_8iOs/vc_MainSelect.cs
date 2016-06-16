using System;
using System.ComponentModel;
using System.Threading.Tasks;
using CoreGraphics;
using Foundation;
using PortableLibrary_8iOs.Foursquareclient.Entities;
using UIKit;
using ImageView;

namespace Phone_8iOs
{
	public partial class vc_MainSelect : UIViewController
	{
		VenueDTO obj;
		public vc_MainSelect(VenueDTO venue) : base("vc_MainSelect", null)
		{
			obj = venue;
		}
		static UIImage FromUrl(string uri)
		{
			using (var url = new NSUrl(uri))
			using (var data = NSData.FromUrl(url))
				return UIImage.LoadFromData(data);
		}
		UIImage imagen;
		float progreso;
		string url;
		UIImageView img_1 = new UIImageView();
		private void bw_DoWork(object sender, DoWorkEventArgs e)
		{
			try
			{
				imagen = FromUrl(url);
				progreso = 100;
			}
			catch
			{
				progreso = 50;
			}
		}
		private void bw_RunWorkerCompleted(object sender,
			RunWorkerCompletedEventArgs e)
		{
			if (imagen != null)
			{
				img_1.Image = imagen;
			}
			else {
				new UIAlertView("Error", "No se encontro la imagen", null, "OK", null).Show();
			}

		}
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			Title = obj.Name;
			UIImageView i_image = new UIImageView();
			i_image.Frame = new CoreGraphics.CGRect(1, 65, 373, 170);
			i_image.Image = UIImage.FromBundle("header.png");


			UILabel lblHead = new UILabel();
			lblHead.Frame = new CoreGraphics.CGRect(1,215, 373, 25);
			lblHead.BackgroundColor = UIColor.DarkGray;
			lblHead.TextAlignment = UITextAlignment.Right;
			lblHead.TextColor = UIColor.White;
			lblHead.Text = obj.Name+"    .";
			View.Add(i_image);
			View.Add(lblHead);

			UILabel lbldescription = new UILabel();
			lbldescription.Frame = new CoreGraphics.CGRect(5, 245, 370, 50);
			lbldescription.Text = "Dirección: " + obj.Address;

			View.Add(lbldescription);
			UILabel lbld = new UILabel();
			lbld.Frame = new CoreGraphics.CGRect(5, 275, 370, 50);
			lbld.Text = obj.City + ", " + obj.State;

			View.Add(lbld);

			var btnFavorite2 = new UIButton(UIButtonType.Custom);
			btnFavorite2.Frame = new CGRect(10, 65, 40, 40);
			string image="star.png";
			if (SQLite.Existe(obj.Name))
			{
				image="starb.png";
			}
			btnFavorite2.SetImage(UIImage.FromBundle(image), UIControlState.Normal);
			btnFavorite2.TouchUpInside += delegate
			{
				if (!SQLite.Existe(obj.Name))
				{
					if (SQLite.InsertarDatos(obj))
					{
						btnFavorite2.SetImage(UIImage.FromBundle("starb.png"), UIControlState.Normal);

					}
					else {

					}
				}
			};
			View.Add(btnFavorite2);


			UILabel lblScore = new UILabel();
			lblScore.Frame = new CoreGraphics.CGRect(1, 320, 390, 70);
			lblScore.BackgroundColor = UIColor.FromRGB(246,246,246);
			lblScore.TextAlignment = UITextAlignment.Right;
			View.Add(lblScore);
			//10-5
			int rate = (int)Math.Round(obj.Rating);
			rate *= 5;
			double r=rate*0.1;
			rate = (int)r;
			UIImageView sc_1 = new UIImageView();
			sc_1.Frame = new CoreGraphics.CGRect(70, 335, 35, 35);
			UIImageView sc_2 = new UIImageView();
			sc_2.Frame = new CoreGraphics.CGRect(115, 335, 35, 35);
			UIImageView sc_3 = new UIImageView();
			sc_3.Frame = new CoreGraphics.CGRect(160, 335, 35, 35);
			UIImageView sc_4 = new UIImageView();
			sc_4.Frame = new CoreGraphics.CGRect(205, 335, 35, 35);
			UIImageView sc_5 = new UIImageView();
			sc_5.Frame = new CoreGraphics.CGRect(250, 335, 35, 35);
			if (rate >= 1)
				sc_1.Image = UIImage.FromBundle("starfill.png");
			else
				sc_1.Image = UIImage.FromBundle("star.png");

			if (rate >= 2)
				sc_2.Image = UIImage.FromBundle("starfill.png");
			else
				sc_2.Image = UIImage.FromBundle("star.png");
			
			if (rate >= 3)
				sc_3.Image = UIImage.FromBundle("starfill.png");
			else
				sc_3.Image = UIImage.FromBundle("star.png");
			
			if (rate >= 4)
				sc_4.Image = UIImage.FromBundle("starfill.png");
			else
				sc_4.Image = UIImage.FromBundle("star.png");

			if (rate >= 5)
				sc_5.Image = UIImage.FromBundle("starfill.png");
			else
				sc_5.Image = UIImage.FromBundle("star.png");
			
		
			View.Add(sc_1);
			View.Add(sc_2);
			View.Add(sc_3);
			View.Add(sc_4);
			View.Add(sc_5);


		

			var btnCall = new UIButton(UIButtonType.Custom);
			btnCall.Frame = new CoreGraphics.CGRect(20, 400, 40, 40);
			btnCall.SetImage(UIImage.FromBundle("call.png"), UIControlState.Normal);
			btnCall.TouchUpInside+=delegate {
				var callURL = new NSUrl("tel:" + obj.Phone);


					if (UIApplication.SharedApplication.CanOpenUrl(callURL))
					{
					//After checking if phone can open NSUrl, it either opens the URL or outputs to the console.

					UIApplication.SharedApplication.OpenUrl(callURL);
					}
					else {
					//OUTPUT to console
					}
			};
			View.Add(btnCall);



			var btnShare = new UIButton(UIButtonType.Custom);
			btnShare.Frame = new CoreGraphics.CGRect(300, 400, 50, 50);
			btnShare.SetImage(UIImage.FromBundle("twitter.png"), UIControlState.Normal);
			btnShare.TouchUpInside += delegate
			  {
				var dvcm = new ImageViewControllerpb();
				NavigationController.PushViewController(dvcm, true);
			  };
			View.Add(btnShare);
			var btnPlaceholder = new UIButton(UIButtonType.Custom);
			btnPlaceholder.Frame = new CoreGraphics.CGRect(160, 400, 50, 50);
			btnPlaceholder.SetImage(UIImage.FromBundle("placeholder.png"), UIControlState.Normal);
			btnPlaceholder.TouchUpInside += delegate
			  {
				  var dvcm = new vcMap(new CoreLocation.CLLocationCoordinate2D[]
				  {
					new CoreLocation.CLLocationCoordinate2D (21.1524644, -101.713862),
					                new CoreLocation.CLLocationCoordinate2D(obj.Lat, obj.Lng)

				}, obj.Name);
				  NavigationController.PushViewController(dvcm, true);
			  };
			View.Add(btnPlaceholder);
			var scrollView = new UIScrollView();
			scrollView.Frame = new CGRect(0, 455, View.Frame.Width, 130);

			scrollView.BackgroundColor = UIColor.FromRGB(246, 246, 246);
			scrollView.AutoresizingMask = UIViewAutoresizing.FlexibleHeight;




			img_1.Frame=new CGRect(30, 15, 60, 60);
			if(obj.Comments.Count>0)
			url = obj.Comments[0].User.Photo;
			BackgroundWorker bw = new BackgroundWorker();
			bw.DoWork +=
				new DoWorkEventHandler(bw_DoWork);
			bw.RunWorkerCompleted +=
				new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
			bw.RunWorkerAsync();

			UILabel lblName = new UILabel();
			lblName.TextColor = UIColor.DarkGray;
			lblName.Frame = new CGRect(130, 20, 250, 25);
			UITextView tvComent = new UITextView();
			tvComent.TextColor = UIColor.DarkGray;
			tvComent.Frame = new CGRect(130, 50, 200, 100);

			int count =  obj.Comments.Count;

			if (count!=0)
			{
				lblName.Text = obj.Comments[0].User.Name;
				scrollView.AddSubview(img_1);
				tvComent.Text = obj.Comments[0].Text;

				scrollView.AddSubview(tvComent);

			}
			else {
				lblName.Text = "No hay comentarios";
			}

			scrollView.AddSubview(lblName);
			View.Add(scrollView);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}



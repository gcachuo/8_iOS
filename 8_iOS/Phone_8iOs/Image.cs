using System;
using System.IO;
using CognitiveService;
using TwitterTweet;
using UIKit;

namespace Phone_8iOs
{
	public partial class Image : UIViewController
	{
		public Image() : base("Image", null)
		{
		}
		public byte[] GetBitmapFromCache()
		{
			try
			{
				return File.ReadAllBytes("/Users/issc811/Downloads/ferrarilogo.png");		
			}
			catch (Exception ex)
			{
				new UIAlertView("ERROR",ex.Message,null,"ok",null);
				return null;
			}

		}
		public override void ViewDidLoad()
		{
			
			base.ViewDidLoad();
			UIImageView i_image = new UIImageView();
			i_image.Frame = new CoreGraphics.CGRect(1, 65, 373, 170);
			i_image.Image = UIImage.FromBundle("cup.jpg");
			View.Add(i_image);

			UILabel lblScore = new UILabel();
			lblScore.Frame = new CoreGraphics.CGRect(1, 320, 390, 70);
			lblScore.BackgroundColor = UIColor.FromRGB(246, 246, 246);
			lblScore.TextAlignment = UITextAlignment.Right;
		

			var btnFavorite2 = new UIButton(UIButtonType.Custom);
			btnFavorite2.Frame = new CoreGraphics.CGRect(10, 65, 40, 40);
			string image = "twitter.png";

			MSCognitiveService cognser = new MSCognitiveService();
			byte[] imagen=GetBitmapFromCache();
			string descripcionImagen=cognser.PeticionImagenDescripcion(imagen);
			lblScore.Text = descripcionImagen;
			View.Add(lblScore);
			btnFavorite2.SetImage(UIImage.FromBundle(image), UIControlState.Normal);
			btnFavorite2.TouchUpInside += delegate
			{
				try
				{
					TWPublicarTweet twtwit = new TWPublicarTweet();
					string MediaId = twtwit.ObtenerIdImagen(imagen);
					if (!twtwit.PeticionPublicarTweet("Proyecto PDMII ISSC,MSCognitiveService.Descripción obtenida: " + descripcionImagen, MediaId))
						new UIAlertView("ERROR", "no se compartio", null, "ok", null).Show();

				}
				catch (Exception ex)
				{
					new UIAlertView("ERROR", ex.Message, null, "ok", null).Show();

				}

			};
			View.Add(btnFavorite2);
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}



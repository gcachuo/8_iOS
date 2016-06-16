using System;

using UIKit;
using PortableLibrary_8iOs;

using System.IO;
using TwitterTweet;
using Foundation;
using System.Net.Http;
using System.Threading.Tasks;

namespace Phone_8iOs
{
	public partial class ViewController : UIViewController
	{
		public ViewController ()
		{
			
		}
		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}
		/*
		public async Task<UIImage> LoadImage(string imageUrl)
		{
			
			var httpClient = new HttpClient();

			Task<byte[]> contentsTask = httpClient.GetByteArrayAsync(imageUrl);

			// await! control returns to the caller and the task continues to run on another thread
			var contents = await contentsTask;

			// load from bytes
			return UIImage.LoadFromData(NSData.FromArray(contents));
		}*/
		public override void ViewDidLoad()
		{
			base.ViewDidLoad(); 

		/*
			UIButton btn = new UIButton (UIButtonType.Custom);
			//someYourUIImageObjectOnUI.Image = await this.LoadImage ("some image url");
			btn.SetImage (UIImage.LoadFromData(, UIControlState.Normal);
			btn.Frame = new CoreGraphics.CGRect (10, 150, 200, 100);
		
			View.AddSubview (btn);
			// Perform any additional setup after loading the view, typically from a nib.
			btn.TouchUpInside += delegate {
				

				//MSCognitiveService cognser=new MSCognitiveService ();
				//byte[] imagen=GetBitmapFromCache();
				//string descripcionImagen=cognser.PeticionImagenDescripcion(imagen);

				//TWPublicarTweet twtwit = new TWPublicarTweet();
				//string MediaId = twtwit.ObtenerIdImagen(imagen);
				//bool publicacionExitosa = twtwit.PeticionPublicarTweet("Proyecto PDMII ISSC,MSCognitiveService.Descripción obtenida: " + descripcionImagen,MediaId);
				//var venueBLO = new VenueBLO (new VenueDAOWSImple());
				//var venues = venueBLO.Explore (10,"tacos",21.099791,-101.720371);
			};*/
		}
		/*
		public byte[] GetBitmapFromCache(){
			return File.ReadAllBytes ("/Users/issc811/Downloads/SmartBuilding.jpg");
		}
		*/
		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


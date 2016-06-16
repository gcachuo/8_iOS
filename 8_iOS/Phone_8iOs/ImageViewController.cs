using System;
using CoreGraphics;
using AssetsLibrary;
using UIKit;
using Foundation;
using CognitiveService;
using TwitterTweet;

namespace ImageView
{

	public partial class ImageViewControllerpb : UIViewController
	{

		UIImagePickerController imagePicker;
		UIButton choosePhotoButton;
		UIImageView imageView;
		public ImageViewControllerpb ():base("ImageViewController",null)
		{
			
		}
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			Title = "Choose Photo";
			View.BackgroundColor = UIColor.White;

			imageView = new UIImageView(new CGRect(10, 150, 300, 300));
			Add(imageView);

			choosePhotoButton = UIButton.FromType(UIButtonType.RoundedRect);
			choosePhotoButton.Frame = new CGRect(10, 80, 200, 40);
			choosePhotoButton.SetTitle("Seleccionar imagen", UIControlState.Normal);
			choosePhotoButton.TouchUpInside += (s, e) => {
				// create a new picker controller
				imagePicker = new UIImagePickerController();

				// set our source to the photo library
				imagePicker.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;

				// set what media types
				imagePicker.MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary);

				imagePicker.FinishedPickingMedia += Handle_FinishedPickingMedia;
				imagePicker.Canceled += Handle_Canceled;

				// show the picker
				NavigationController.PresentModalViewController(imagePicker, true);
				//UIPopoverController picc = new UIPopoverController(imagePicker);

			};
			View.Add(choosePhotoButton);
		}

		// Do something when the
		void Handle_Canceled(object sender, EventArgs e)
		{
			Console.WriteLine("picker cancelled");
			imagePicker.DismissModalViewController(true);
		}

		// This is a sample method that handles the FinishedPickingMediaEvent
		protected void Handle_FinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs e)
		{
			// determine what was selected, video or image
			bool isImage = false;
			switch(e.Info[UIImagePickerController.MediaType].ToString())
			{
			case "public.image":
				Console.WriteLine("Image selected");
				isImage = true;
				break;

			case "public.video":
				Console.WriteLine("Video selected");
				break;
			}

			Console.Write("Reference URL: [" + UIImagePickerController.ReferenceUrl + "]");

			// get common info (shared between images and video)
			NSUrl referenceURL = e.Info[new NSString("UIImagePickerControllerReferenceUrl")] as NSUrl;
			if(referenceURL != null)
				Console.WriteLine(referenceURL.ToString());

			// if it was an image, get the other image info
			if(isImage)
			{

				// get the original image
				UIImage originalImage = e.Info[UIImagePickerController.OriginalImage] as UIImage;
				if(originalImage != null)
				{
					// do something with the image
					Console.WriteLine("got the original image");
					imageView.Image = originalImage;
				}

				// get the edited image
				UIImage editedImage = e.Info[UIImagePickerController.EditedImage] as UIImage;
				if(editedImage != null)
				{
					// do something with the image
					Console.WriteLine("got the edited image");
					imageView.Image = editedImage;
				}

				//- get the image metadata
				NSDictionary imageMetadata = e.Info[UIImagePickerController.MediaMetadata] as NSDictionary;
				if(imageMetadata != null)
				{
					// do something with the metadata
					Console.WriteLine("got image metadata");
				}

			}
			// if it's a video
			else
			{
				// get video url
				NSUrl mediaURL = e.Info[UIImagePickerController.MediaURL] as NSUrl;
				if(mediaURL != null)
				{
					//
					Console.WriteLine(mediaURL.ToString());
				}
			}

			// dismiss the picker
			imagePicker.DismissModalViewController(true);
			UITextView lblScore = new UITextView();
			lblScore.Frame = new CoreGraphics.CGRect(1, 500, 370, 70);
			lblScore.BackgroundColor = UIColor.FromRGB(246, 246, 246);
			lblScore.TextAlignment = UITextAlignment.Center;
			UIImage imagenT = imageView.Image;
			NSData imageData = imagenT.AsPNG();
			var btnFavorite2 = new UIButton(UIButtonType.Custom);
			btnFavorite2.Frame = new CoreGraphics.CGRect(10, 400, 40, 40);
			string image = "twitter.png";
			byte[] myArr = new Byte[imageData.Length];
			System.Runtime.InteropServices.Marshal.Copy(imageData.Bytes, myArr, 0, Convert.ToInt32(imageData.Length));
			MSCognitiveService cognser = new MSCognitiveService();
			string descripcionImagen= cognser.PeticionImagenDescripcion(myArr);
			lblScore.Text = descripcionImagen;
			View.Add(lblScore);
			btnFavorite2.SetImage(UIImage.FromBundle(image), UIControlState.Normal);
			btnFavorite2.TouchUpInside += delegate
			{
				try
				{
					TWPublicarTweet twtwit = new TWPublicarTweet();
					string MediaId = twtwit.ObtenerIdImagen(myArr);
					if (!twtwit.PeticionPublicarTweet("Proyecto PDMII ISSC,MSCognitiveService.Descripción obtenida: " + descripcionImagen, MediaId))
						new UIAlertView("ERROR", "no se compartio", null, "ok", null).Show();

				}
				catch (Exception ex)
				{
					new UIAlertView("ERROR", ex.Message, null, "ok", null).Show();

				}

			};
			View.Add (btnFavorite2);
		}
	}
}
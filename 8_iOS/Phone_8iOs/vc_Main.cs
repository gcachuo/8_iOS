using System;
using UIKit;
using PortableLibrary_8iOs;
using PortableLibrary_8iOs.Foursquareclient.Entities;
using System.Collections.Generic;

namespace Phone_8iOs
{
	public partial class vc_Main : UIViewController
	{
		public vc_Main() : base("vc_Main", null)
		{
		}


		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			//Motor de busqueda
			UISearchBar i_search = new UISearchBar();
			i_search.Frame = new CoreGraphics.CGRect(0, 65, 375, 44);
			i_search.TextChanged+=delegate {
				//consulta en linq para verificar que el contenido de la busqueda este disponible
				try
				{
					LoadButtons(Loadlista(i_search.Text));
				}
				catch (Exception ex)
				{

				}

			};
			View.AddSubview(i_search);

			//categories
			UIButton btnFood = new UIButton(UIButtonType.Custom);
			btnFood.Frame = new CoreGraphics.CGRect(40, 115, 60, 60);
			btnFood.BackgroundColor = UIColor.White;
			btnFood.SetImage(UIImage.FromBundle("category/cutlery.png"), UIControlState.Normal);
			btnFood.TintColor = UIColor.White;
			btnFood.TouchUpInside += delegate
			{
				LoadButtons(Loadlista("comida"));
			};
			UIButton btnCoffe = new UIButton(UIButtonType.Custom);
			btnCoffe.Frame = new CoreGraphics.CGRect(105, 115, 60, 60);
			btnCoffe.BackgroundColor = UIColor.White;
			btnCoffe.SetImage(UIImage.FromBundle("category/cup.png"), UIControlState.Normal);
			btnCoffe.TintColor = UIColor.White;
			btnCoffe.TouchUpInside += delegate
			{
				LoadButtons(Loadlista("cafe"));
			};
			UIButton btnBar= new UIButton(UIButtonType.Custom);
			btnBar.Frame = new CoreGraphics.CGRect(170, 115, 60, 60);
			btnBar.BackgroundColor = UIColor.White;
			btnBar.SetImage(UIImage.FromBundle("category/pint.png"), UIControlState.Normal);
			btnBar.TintColor = UIColor.White;
			btnBar.TouchUpInside += delegate
			{
				LoadButtons(Loadlista("bar"));
			};
			UIButton btnCinema = new UIButton(UIButtonType.Custom);
			btnCinema.Frame = new CoreGraphics.CGRect(240, 115, 60, 60);
			btnCinema.BackgroundColor = UIColor.White;
			btnCinema.SetImage(UIImage.FromBundle("category/video-camera.png"), UIControlState.Normal);
			btnCinema.TintColor = UIColor.White;
			btnCinema.TouchUpInside += delegate
			{
				LoadButtons(Loadlista("cinema"));
			};

			View.Add(btnBar);
			View.Add(btnCoffe);
			View.Add(btnCinema);
			View.Add(btnFood);
			LoadButtons(Loadlista("comida"));

			//lista de lugares

			//valores de coordenadas





		}
		private List<VenueDTO> Loadlista(string description)
		{
			var venueBLO = new VenueBLO(new VenueDAOWSImple());
			var venues = venueBLO.Explore(10, description, 21.1532015, -101.7133507);
			return venues;
		}
		private void LoadButtons(List<VenueDTO> list)
		{

			UIButton btnO1 = new UIButton(UIButtonType.Custom);
			UIButton btnO2 = new UIButton(UIButtonType.Custom);
			UIButton btnO3 = new UIButton(UIButtonType.Custom);
			UIButton btnO4 = new UIButton(UIButtonType.Custom);
			UIButton btnO5 = new UIButton(UIButtonType.Custom);
			UIButton btnO6 = new UIButton(UIButtonType.Custom);
			UIButton btnO7 = new UIButton(UIButtonType.Custom);
			UIButton btnO8 = new UIButton(UIButtonType.Custom);
			UIButton btnO9 = new UIButton(UIButtonType.Custom);
			UIButton btn10 = new UIButton(UIButtonType.Custom);
			btnO1.Frame = new CoreGraphics.CGRect(5, 210, 180, 70);
			btnO1.SetImage(UIImage.FromBundle("btn.png"), UIControlState.Normal);

			btnO2.Frame = new CoreGraphics.CGRect(190, 210, 180, 70);
			btnO2.SetImage(UIImage.FromBundle("btn.png"), UIControlState.Normal);

			btnO3.Frame = new CoreGraphics.CGRect(5, 285, 180, 70);
			btnO3.SetImage(UIImage.FromBundle("btn.png"), UIControlState.Normal);

			btnO4.Frame = new CoreGraphics.CGRect(190, 285, 180, 70);
			btnO4.SetImage(UIImage.FromBundle("btn.png"), UIControlState.Normal);

			btnO5.Frame = new CoreGraphics.CGRect(5, 360, 180, 70);
			btnO5.SetImage(UIImage.FromBundle("btn.png"), UIControlState.Normal);

			btnO6.Frame = new CoreGraphics.CGRect(190, 360, 180, 70);
			btnO6.SetImage(UIImage.FromBundle("btn.png"), UIControlState.Normal);

			btnO7.Frame = new CoreGraphics.CGRect(5, 435, 180, 70);
			btnO7.SetImage(UIImage.FromBundle("btn.png"), UIControlState.Normal);

			btnO8.Frame = new CoreGraphics.CGRect(190, 435, 180, 70);
			btnO8.SetImage(UIImage.FromBundle("btn.png"), UIControlState.Normal);

			btnO9.Frame = new CoreGraphics.CGRect(5, 510, 180, 70);
			btnO9.SetImage(UIImage.FromBundle("btn.png"), UIControlState.Normal);

			btn10.Frame = new CoreGraphics.CGRect(190, 510, 180, 70);
			btn10.SetImage(UIImage.FromBundle("btn.png"), UIControlState.Normal);

			UILabel lb01 = new UILabel();
			lb01.Frame = new CoreGraphics.CGRect(15, 210, 170, 70);
			lb01.TextColor = UIColor.White;
			lb01.TextAlignment = UITextAlignment.Center;
			UILabel lb02 = new UILabel();
			lb02.Frame = new CoreGraphics.CGRect(200, 210, 170, 70);
			lb02.TextColor = UIColor.White;
			lb02.TextAlignment = UITextAlignment.Center;
			UILabel lb03 = new UILabel();
			lb03.Frame = new CoreGraphics.CGRect(15, 285, 170, 70);
			lb03.TextColor = UIColor.White;
			lb03.TextAlignment = UITextAlignment.Center;
			UILabel lb04 = new UILabel();
			lb04.Frame = new CoreGraphics.CGRect(200, 285, 170, 70);
			lb04.TextColor = UIColor.White;
			lb04.TextAlignment = UITextAlignment.Center;
			UILabel lb05 = new UILabel();
			lb05.Frame = new CoreGraphics.CGRect(15, 360, 170, 70);
			lb05.TextColor = UIColor.White;
			lb05.TextAlignment = UITextAlignment.Center;
			UILabel lb06 = new UILabel();
			lb06.Frame = new CoreGraphics.CGRect(200, 360, 170, 70);
			lb06.TextColor = UIColor.White;
			lb06.TextAlignment = UITextAlignment.Center;
			UILabel lb07 = new UILabel();
			lb07.Frame = new CoreGraphics.CGRect(15, 435, 170, 70);
			lb07.TextColor = UIColor.White;
			lb07.TextAlignment = UITextAlignment.Center;
			UILabel lb08 = new UILabel();
			lb08.Frame = new CoreGraphics.CGRect(200, 435, 170, 70);
			lb08.TextColor = UIColor.White;
			lb08.TextAlignment = UITextAlignment.Center;
			UILabel lb09 = new UILabel();
			lb09.Frame = new CoreGraphics.CGRect(15, 510, 170, 70);
			lb09.TextColor = UIColor.White;
			lb09.TextAlignment = UITextAlignment.Center;
			UILabel lb10 = new UILabel();
			lb10.Frame = new CoreGraphics.CGRect(200, 510, 170, 70);
			lb10.TextColor = UIColor.White;
			lb10.TextAlignment = UITextAlignment.Center;



			if (list[0] != null)
			{
				lb01.Text = list[0].Name;
				btnO1.TouchUpInside += delegate
				{
					var dvc = new vc_MainSelect(list[0]);
					NavigationController.PushViewController(dvc, true);
				};
				if (View.Subviews.Equals(btnO1))
				{
					View.Delete(btnO1);
					View.Delete(lb01);
				}
				View.Add(btnO1);
				View.Add(lb01);
			}
			if (list[1] != null)
			{
				lb02.Text = list[1].Name;
				btnO2.TouchUpInside += delegate
				{
					var dvc = new vc_MainSelect(list[1]);
					NavigationController.PushViewController(dvc, true);
				};
				if (View.Subviews.Equals(btnO2))
				{
					View.Delete(btnO2);
					View.Delete(lb02);
				}
				View.Add(btnO2);
				View.Add(lb02);
			}
			if (list[2] != null)
			{
				lb03.Text = list[2].Name;
				btnO3.TouchUpInside += delegate
				{
					var dvc = new vc_MainSelect(list[0]);
					NavigationController.PushViewController(dvc, true);
				};
				if (View.Subviews.Equals(btnO3))
				{
					View.Delete(btnO3);
					View.Delete(lb03);
				}
				View.Add(btnO3);
				View.Add(lb03);
			}
			if (list[3] != null)
			{
				lb04.Text = list[3].Name;
				btnO4.TouchUpInside += delegate
				{
					var dvc = new vc_MainSelect(list[3]);
					NavigationController.PushViewController(dvc, true);
				};
				if (View.Subviews.Equals(btnO4))
				{
					View.Delete(btnO4);
					View.Delete(lb04);
				}
				View.Add(btnO4);
				View.Add(lb04);
			}
			if (list[4] != null)
			{
				lb05.Text = list[4].Name;
				btnO5.TouchUpInside += delegate
				{
					var dvc = new vc_MainSelect(list[4]);
					NavigationController.PushViewController(dvc, true);
				};
				if (View.Subviews.Equals(btnO1))
				{
					View.Delete(btnO5);
					View.Delete(lb05);
				}
				View.Add(btnO5);
				View.Add(lb05);
			}
			if (list[5] != null)
			{
				lb06.Text = list[5].Name;
				btnO6.TouchUpInside += delegate
				{
					var dvc = new vc_MainSelect(list[5]);
					NavigationController.PushViewController(dvc, true);
				};
				if (View.Subviews.Equals(btnO6))
				{
					View.Delete(btnO6);
					View.Delete(lb06);
				}
				View.Add(btnO6);
				View.Add(lb06);
			}
			if (list[6] != null)
			{
				lb07.Text = list[6].Name;
				btnO7.TouchUpInside += delegate
				{
					var dvc = new vc_MainSelect(list[6]);
					NavigationController.PushViewController(dvc, true);
				};
				if (View.Subviews.Equals(btnO7))
				{
					View.Delete(btnO7);
					View.Delete(lb07);
				}
				View.Add(btnO7);
				View.Add(lb07);
			}
			if (list[7] != null)
			{
				lb08.Text = list[7].Name;
				btnO8.TouchUpInside += delegate
				{
					var dvc = new vc_MainSelect(list[7]);
					NavigationController.PushViewController(dvc, true);
				};
				if (View.Subviews.Equals(btnO8))
				{
					View.Delete(btnO8);
					View.Delete(lb08);
				}
				View.Add(btnO8);
				View.Add(lb08);
			}
			if (list[8] != null)
			{
				lb09.Text = list[8].Name;
				btnO9.TouchUpInside += delegate
				{
					var dvc = new vc_MainSelect(list[8]);
					NavigationController.PushViewController(dvc, true);
				};
				if (View.Subviews.Equals(btnO9))
				{
					View.Delete(btnO9);
					View.Delete(lb09);
				}
				View.Add(btnO9);
				View.Add(lb09);
			}
			if (list[9] != null)
			{
				lb10.Text = list[9].Name;
				btn10.TouchUpInside += delegate
				{
					var dvc = new vc_MainSelect(list[9]);
					NavigationController.PushViewController(dvc, true);
				};
				if (View.Subviews.Equals(btn10))
				{
					View.Delete(btn10);
					View.Delete(lb10);
				}
				View.Add(btn10);
				View.Add(lb10);
			}
			UIButton btnFv = new UIButton(UIButtonType.Custom);
			btnFv.Frame = new CoreGraphics.CGRect(300, 600, 40, 40);
			btnFv.SetImage(UIImage.FromBundle("starb.png"), UIControlState.Normal);
			btnFv.TouchUpInside += delegate
				{
					var dvc = new Favoritesdvc();
					NavigationController.PushViewController(dvc, true);
				};
			View.Add(btnFv);
		}
		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}



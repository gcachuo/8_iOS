using System;
using CoreLocation;
using Foundation;
using MapKit;
using UIKit;

namespace Phone_8iOs
{
	public partial class vcMap : UIViewController
	{
		CLLocationCoordinate2D[] coordenada = new CLLocationCoordinate2D[2];
		string lugar;
		public vcMap(CLLocationCoordinate2D[] coo, string place) : base("vcMap", null)
		{
			coordenada = coo;
			lugar = place;
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			MKMapView mapView = new MKMapView(View.Bounds);

			NavigationItem.Title = "Ubicación";
			mapView.AutoresizingMask = UIViewAutoresizing.FlexibleDimensions;
			View.AddSubview(mapView);
			var ann = new MKPointAnnotation[] {
				new MKPointAnnotation () {
					Title = "Universidad de la Salle Bajío", Coordinate = coordenada[0]
				}, new MKPointAnnotation(){
					Title = lugar,Coordinate=coordenada[1]
				}
			};

			Do_Rute(Add_Annotation(ann, coordenada, mapView), UIColor.Green, coordenada, mapView);

		}

			// Perform any additional setup after loading the view, typically from a nib.

		private MKDirectionsRequest Add_Annotation(MKPointAnnotation[] anotacion, CLLocationCoordinate2D[] coord, MKMapView mapView)
		{

			mapView.ShowAnnotations(new MKPointAnnotation[] { anotacion[0], anotacion[1] }, false);

			var entydict = new NSDictionary();

			var req = new MKDirectionsRequest()
			{
				Source = new MKMapItem(new MKPlacemark(coord[0], entydict)),
				Destination = new MKMapItem(new MKPlacemark(coord[1], entydict)),
				TransportType = MKDirectionsTransportType.Automobile
			};

			return req;

		}

		private void Do_Rute(MKDirectionsRequest req, UIColor color, CLLocationCoordinate2D[] coord, MKMapView mapView)
		{
			var dir = new MKDirections(req);

			dir.CalculateDirections((response, error) =>
			{
				if (error == null)
				{
					var rute = response.Routes[0];
					var rteL = new MKPolylineRenderer(rute.Polyline)
					{
						LineWidth = 5.0f,
						StrokeColor = color
					};
					mapView.OverlayRenderer = (mv, ol) => rteL;
					var circleoverlay = MKCircle.Circle(mapView.CenterCoordinate, 1000);
					mapView.AddOverlay(circleoverlay);

					int index = 0;

					foreach (var position in coord)
					{
						coord[index] = new CLLocationCoordinate2D(position.Latitude, position.Longitude);
						index++;
					}
					var routeOverlay = MKPolyline.FromCoordinates(coord);


					mapView.AddOverlay(routeOverlay);
					mapView.SetCenterCoordinate(coord[1], true);

					//mapView.AddOverlay(rute.Polyline, MKOverlayLevel.AboveRoads);

				}
				else {
					Console.WriteLine("Error");
				}
			});
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}



using System;
using MonoTouch.Dialog;
using UIKit;
using System.Collections.Generic;
using PortableLibrary_8iOs.Foursquareclient.Entities;
using System.Linq;

namespace Phone_8iOs
{
	public class Favoritesdvc : DialogViewController
	{
		public Favoritesdvc() : base(UITableViewStyle.Grouped, null,true)
		{
			List<StringElement> elements = new List<StringElement>();
			List<int> numeros;
			List<VenueDTO> list = SQLite.RecuperarDatos();
			numeros = System.Linq.Enumerable.Range(1, list.Count).ToList();
			numeros.ForEach(i => elements.Add(new StringElement(list[i - 1].Name, () => { NavigationController.PushViewController(new vc_MainSelect(list[i - 1]), true); })));
			var section = new Section("favoritos");
			section.AddAll(elements);
			Root = new RootElement("Archivos") { section };
			var btnAdd = new UIBarButtonItem("+", UIBarButtonItemStyle.Plain, (sender, e) =>
			{
				NavigationController.PushViewController(new ViewController(), true);
			});

			NavigationItem.RightBarButtonItem = btnAdd;
		}
	}
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PortableLibrary_8iOs.Foursquareclient.Entities;
using SQLite;
namespace Phone_8iOs
{
	public static class SQLite
	{
		
		static string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Data.db3");

		public static void CrearBaseDatos()
		{
			try
			{
				
				if (File.Exists(dbPath)){
				//	File.Delete(dbPath);
				}
				var db = new SQLiteConnection(dbPath);
				db.CreateTable<VenueDTO>();
				db.Close();
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}
		public static bool InsertarDatos(VenueDTO item)
		{
			try
			{
				var db = new SQLiteConnection(dbPath);
				db.Insert(item,typeof (VenueDTO));
				db.Close();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
		public static List<VenueDTO> RecuperarDatos()
		{
			var db = new SQLiteConnection(dbPath);
			try
			{
				return db.Table<VenueDTO>().ToList();
			}
			catch (Exception)
			{
				return null;
			}
		}
		public static bool Existe(string vdto)
		{
			var db = new SQLiteConnection(dbPath);
			try
			{
				//var v=db.Table<VenueDTO>().Where(n => n.Name.Equals( vdto)).FirstOrDefault();
				var list= db.Table<VenueDTO>().ToList();
				foreach (var i in list)
				{
					if (i.Name == vdto)
						return true;
				}
				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}


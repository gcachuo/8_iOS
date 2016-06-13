using System;
using System.Net;

namespace Library_8iOs
{
    public class manejoDeImagenes
    {
        public string descarga(string url,string ext)
        {
            try
            {
                var web = new WebClient();
                web.DownloadFile(url, "imagen." + ext);
                return "true";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}

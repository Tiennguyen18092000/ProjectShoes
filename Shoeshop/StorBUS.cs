using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shoeshop
{
    class StorBUS
    {
        String URI = "https://bsite.net/hoangan10012/";
        public List<Stor> GetAll()
        {
            WebClient client = new WebClient();
            String res = client.DownloadString(URI + "api/Storage");
            List<Stor> stor = JsonConvert.DeserializeObject<List<Stor>>(res);
            return stor;
        }
        public Stor GetDetails(int id)
        {
            WebClient client = new WebClient();
            String res = client.DownloadString(URI + "api/Storage/" + id);
            Stor snk = JsonConvert.DeserializeObject<Stor>(res);
            return snk;
        }

        public bool Add(Stor snk)
        {
            String data = JsonConvert.SerializeObject(snk);
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            String res = client.UploadString(URI + "api/Storage", "POST", data);
            bool result = bool.Parse(res);
            return result;

        }
        public bool Update(Stor snk)
        {
            String data = JsonConvert.SerializeObject(snk);
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            String res = client.UploadString(URI + "api/Storage/" + snk.id, "PUT", data);
            bool result = bool.Parse(res);
            return result;
        }
        public bool Delete(int id)
        {
            WebClient client = new WebClient();
            String res = client.UploadString(URI + "api/Storage/" + id, "DELETE", "");
            bool result = bool.Parse(res);
            return result;
        }
    }
}

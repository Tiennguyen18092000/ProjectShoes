using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shoeshop
{
    class HomepageBUS
    {
        String URI = "https://bsite.net/hoangan10012/";
        public List<Sneaker> GetAll()
        {
            WebClient client = new WebClient();
            String res = client.DownloadString(URI + "api/sneakers");
            List<Sneaker> snk = JsonConvert.DeserializeObject<List<Sneaker>>(res);
            return snk;
        }
        public Sneaker GetDetails(int id)
        {
            WebClient client = new WebClient();
            String res = client.DownloadString(URI + "api/sneakers/" + id);
            Sneaker snk = JsonConvert.DeserializeObject<Sneaker>(res);
            return snk;
        }
        public bool Add(Sneaker snk)
        {
            String data = JsonConvert.SerializeObject(snk);
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            String res = client.UploadString(URI + "api/sneakers", "POST", data);
            bool result = bool.Parse(res);
            return result;

        }
        public bool Update(Sneaker snk)
        {
            String data = JsonConvert.SerializeObject(snk);
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            String res = client.UploadString(URI + "api/sneakers/" + snk.id, "PUT", data);
            bool result = bool.Parse(res);
            return result;
        }
        public bool Delete(int id)
        {
            WebClient client = new WebClient();
            String res = client.UploadString(URI + "api/sneakers/" + id, "DELETE", "");
            bool result = bool.Parse(res);
            return result;
        }
        public List<Sneaker> Search(String keyword)
        {
            WebClient client = new WebClient();
            String res = client.DownloadString(URI + "api/sneakers/search/" + keyword);
            List<Sneaker> snks = JsonConvert.DeserializeObject<List<Sneaker>>(res);
            return snks;
        }
    }
}

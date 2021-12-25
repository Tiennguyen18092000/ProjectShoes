using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shoeshop
{
    class CateBUS
    {
        String URI = "https://bsite.net/hoangan10012/";
        public List<Category> GetAll()
        {
            WebClient client = new WebClient();
            String res = client.DownloadString(URI + "api/cate");
            List<Category> cate = JsonConvert.DeserializeObject<List<Category>>(res);
            return cate;
        }
        public Category GetDetails(int id)
        {
            WebClient client = new WebClient();
            String res = client.DownloadString(URI + "api/cate/" + id);
            Category snk = JsonConvert.DeserializeObject<Category>(res);
            return snk;
        }
        public bool Add(Category snk)
        {
            String data = JsonConvert.SerializeObject(snk);
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            String res = client.UploadString(URI + "api/cate", "POST", data);
            bool result = bool.Parse(res);
            return result;

        }
        public bool Update(Category snk)
        {
            String data = JsonConvert.SerializeObject(snk);
            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            String res = client.UploadString(URI + "api/cate/" + snk.id, "PUT", data);
            bool result = bool.Parse(res);
            return result;
        }
        public bool Delete(int id)
        {
            WebClient client = new WebClient();
            String res = client.UploadString(URI + "api/cate/" + id, "DELETE", "");
            bool result = bool.Parse(res);
            return result;
        }
        public List<Category> Search(String keyword)
        {
            WebClient client = new WebClient();
            String res = client.DownloadString(URI + "api/cate/search/" + keyword);
            List<Category> snks = JsonConvert.DeserializeObject<List<Category>>(res);
            return snks;
        }
    }
}

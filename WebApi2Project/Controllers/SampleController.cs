using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebApi2Project.Models;

namespace WebApi2Project.Controllers
{
    public class SampleController : ApiController
    {
        public string GetTime([FromUri]Time t)
        {
            return string.Format("Received Time:{0}:{1}.{2}", t.Hour, t.Minute, t.Second);
        }

        async Task GetData()
        {
            StringBuilder result = new StringBuilder();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(HttpContext.Current.Request.Url.AbsoluteUri);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("api/products").Result;

                if (response.IsSuccessStatusCode)
                {
                    var products = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
                    foreach (var p in products)
                    {
                        result.Append(string.Format("{0} - [Price: {1} Category: {2}]", p.Name, p.Price, p.Category));
                    }
                }
                else
                {
                    result.Append(string.Format("Error Code:- {0} Error Details: {1}", (int)response.StatusCode, response.ReasonPhrase));
                }
            }
            data.Text = result.ToString();
        }
        public class Time
        {
            public int Hour { get; set; }
            public int Minute { get; set; }
            public int Second { get; set; }
        }
    }
}
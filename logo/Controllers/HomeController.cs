using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace logo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public string Search(string queryName = "", string type = "CHN", string intcls = "9")
        {
            var url = "http://sbcx.saic.gov.cn:9080/tmois/wsjscx_getSlectListBySys.xhtml";
            string myParameters = "pagenum=1&pagesize=1000&sum=&countpage=&goNum=1&type=" + type + "&intcls=" + intcls + "&content=" + HttpUtility.UrlEncode(queryName) + "&si=&sf=";
            string result;
            using (MyWebClient wc = new MyWebClient())
            {
                wc.Encoding = System.Text.Encoding.UTF8;
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                wc.Headers[HttpRequestHeader.Referer] = "http://sbcx.saic.gov.cn:9080/tmois/wsjscx_getSlectListBySys.xhtml";
                result = wc.UploadString(url, "POST", myParameters);
            }
            return result;
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }

    class MyWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri uri)
        {
            WebRequest w = base.GetWebRequest(uri);
            w.Timeout = 3 * 60 * 1000;
            return w;
        }
    }
}
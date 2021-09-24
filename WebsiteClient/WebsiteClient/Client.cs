using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.Net;
using System.IO;

namespace WebsiteClient
{
    class Client
    {

        static void Main(string[] args)
        {
            if (args.Length != 2 || !args.Any(a => a == "-h"))
            {
                Usage();
            }

            var host = args[1];
            var loginRequest = new LoginRequest();
            var loginURI = new Uri(string.Format("{0}/sessions", host));
            var loginData = Encoding.UTF8.GetBytes("email=fake@test.com&password=ThisIsFake&commit=submit&authenticity_token=token");

            using (HttpWebResponse loginResponse = loginRequest.Login(loginURI, loginData))
            {
                foreach (Cookie c in loginResponse.Cookies)
                {
                    Print(String.Format("Cookie{{name: {0}, value: {1}, path: {2}, Domain: {3}}}", c.Name, c.Value, c.Path, c.Domain));
                }
                using (var responseStream = new StreamReader(loginResponse.GetResponseStream()))
                {
                    Print(responseStream.ReadToEnd());
                }

                //Read my current watchlist
                var watchlistURI = new Uri(string.Format("{0}/my_nzx/watchlist", host));
                HttpWebRequest getWatchlist = RequestFactory.GetGetRequest(watchlistURI, loginRequest.Cookies);

                using (HttpWebResponse watchlistResponse = (HttpWebResponse)getWatchlist.GetResponse())
                {
                    using (var responseStream = new StreamReader(watchlistResponse.GetResponseStream()))
                    {
                        Print(responseStream.ReadToEnd());
                    }
                }

                //var watchlistURI = new Uri(string.Format("{0}/my_nzx/watchlist/instruments", host));
                //var addWatchlistData = Encoding.UTF8.GetBytes("authenticity_token=hIldFpaRhvp4aQkNEXaCOz3kcl3FsVHi1iJ3pU1nQ+U=&utf8=&#x2713;&commit=Add&code=KIP");
                //HttpWebRequest addKIPToWatchlistRequest = RequestFactory.GetPostRequest(watchlistURI, addWatchlistData, loginRequest.Cookies);

                //using (HttpWebResponse watchlistUpdateResponse = (HttpWebResponse)addKIPToWatchlistRequest.GetResponse())
                //{
                //    using (var responseStream = new StreamReader(watchlistUpdateResponse.GetResponseStream()))
                //    {
                //        Print(responseStream.ReadToEnd());
                //    }
                //}
            }

        }

        //    var currentCookies = GetCurrentCookiesForSite(loginURI);

        //    var logoutURI = new Uri(string.Format("{0}/Members/Logout.aspx?logout=true",args[1]));
        //    var request = (HttpWebRequest)WebRequest.Create(logoutURI);
        //    request.Proxy = null;
        //    request.Method = _postMethod;
        //    request.ContentType = _formContentType;
        //    request.CookieContainer = currentCookies;            

        //    var postData = Encoding.UTF8.GetBytes("logout_auto=Turn off auto-login");
        //    request.ContentLength = postData.Length;

        //    var myFirefoxSession = @"%7bE2FEA53B-F739-4FF8-A7BE-7B9392AE92A0%7d";            

        //    Print("Attempting Logout");

        //    using (Stream requestStream = request.GetRequestStream())
        //    {
        //        requestStream.Write(postData, 0, postData.Length);
        //        using (var response = (HttpWebResponse)request.GetResponse())
        //        {
        //            foreach (Cookie c in response.Cookies)
        //            {
        //                Print(String.Format("Cookie{{name: {0}, value: {1}, path: {2}, Domain: {3}}}", c.Name, c.Value, c.Path, c.Domain));
        //            }
        //        }
        //    }

        //}

        public static void Usage()
        {
            Print(String.Format("{0}.exe -h {{HOSTNAME}}", Assembly.GetExecutingAssembly().GetName().Name));
        }

        public static CookieContainer GetCurrentCookiesForSite(Uri siteURI)
        {

            var cc = new CookieContainer();

            var request = (HttpWebRequest)WebRequest.Create(siteURI);
            request.Proxy = (null);
            request.CookieContainer = cc;

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                foreach (Cookie c in response.Cookies)
                {
                    Print(String.Format("Cookie{{name: {0}, value: {1}, path: {2}, Domain: {3}}}", c.Name, c.Value, c.Path, c.Domain));
                }
            }

            return cc;
        }


        public static void Print(object o)
        {
#if DEBUG
            Debug.WriteLine(o);    
#else
            Console.WriteLine(o);
#endif
        }
    }
}

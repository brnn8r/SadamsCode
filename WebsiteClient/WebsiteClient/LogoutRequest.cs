using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace WebsiteClient
{
    class LogoutRequest : ILogoutRequest, ICookieContainer
    {
        private HttpWebRequest _request;
        public CookieContainer Cookies { get; private set; }

        public LogoutRequest()
        {
            Cookies = new CookieContainer();                        
        }

        public HttpWebResponse Logout(Uri uri, byte[] logoutData, CookieContainer cookies)
        {
            Cookies = cookies;
            _request = RequestFactory.GetPostRequest(uri, logoutData, Cookies);                        

            return (HttpWebResponse)_request.GetResponse();
        }

        public HttpWebResponse Logout(string uri, byte[] logoutData, CookieContainer cookies)
        {
            return Logout(new Uri(uri), logoutData, cookies);
        }
    }
}

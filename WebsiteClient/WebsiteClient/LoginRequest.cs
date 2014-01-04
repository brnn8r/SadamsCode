using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace WebsiteClient
{
    class LoginRequest : ILoginRequest, ICookieContainer 
    {
        private HttpWebRequest _request;
        public CookieContainer Cookies { get; private set; }

        public LoginRequest()
        {
            Cookies = new CookieContainer();            
        }

        public HttpWebResponse Login(Uri uri, byte[] loginData)
        {
            _request = RequestFactory.GetPostRequest(uri, loginData, Cookies);            
            _request.CookieContainer = Cookies;            

            return (HttpWebResponse)_request.GetResponse();
        }

        public HttpWebResponse Login(string uri, byte[] loginData)
        {
            return Login(new Uri(uri), loginData);
        }
    }
}

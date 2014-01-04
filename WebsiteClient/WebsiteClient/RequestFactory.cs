using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace WebsiteClient
{
    class RequestFactory
    {
        public static HttpWebRequest GetPostRequest(Uri uri, byte[] postData, CookieContainer cookies)
        {
            var postRequest = (HttpWebRequest)WebRequest.Create(uri);

            postRequest.Proxy = null;
            postRequest.Method = Constants.PostMethod;
            postRequest.ContentType = Constants.FormContentType;
            postRequest.CookieContainer = cookies;

            using (Stream postStream = postRequest.GetRequestStream())
            {
                postStream.Write(postData, 0, postData.Length);
            }

            return postRequest;
        }

        public static HttpWebRequest GetGetRequest(Uri uri, CookieContainer cookies)
        {
            var getRequest = (HttpWebRequest)WebRequest.Create(uri);

            getRequest.Proxy = null;
            getRequest.Method = Constants.GetMethod;
            getRequest.CookieContainer = cookies;

            return getRequest;
        }

        public static HttpWebRequest GetPostRequest(String uri, byte[] postData, CookieContainer cookies)
        {
            return GetPostRequest(new Uri(uri), postData, cookies);
        }

        public static HttpWebRequest GetGetRequest(String uri, CookieContainer cookies)
        {
            return GetGetRequest(new Uri(uri), cookies);
        }


    }
}

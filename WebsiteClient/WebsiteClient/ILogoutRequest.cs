using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace WebsiteClient
{
    interface ILogoutRequest
    {
        HttpWebResponse Logout(Uri uri, byte[] logoutData, CookieContainer cookies);
        HttpWebResponse Logout(string uri, byte[] logoutData, CookieContainer cookies);       
    }
}

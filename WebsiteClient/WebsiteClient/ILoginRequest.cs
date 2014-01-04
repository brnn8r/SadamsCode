using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net; 

namespace WebsiteClient
{
    interface ILoginRequest
    {
        HttpWebResponse Login(Uri uri, byte[] loginData);
        HttpWebResponse Login(string uri, byte[] loginData);       
    }
}

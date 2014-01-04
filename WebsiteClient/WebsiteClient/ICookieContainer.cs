using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net; 

namespace WebsiteClient
{
    interface ICookieContainer
    {
        CookieContainer Cookies { get; }
    }
}

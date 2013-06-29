using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CheckSum
{
    public class SHA1CheckSumGenerator : ICheckSumGenerator
    {
        public string ComputeCheckSum(byte[] data)
        {
            using (var crypto = new SHA1CryptoServiceProvider())
            {                   
                return BitConverter.ToString(crypto.ComputeHash(data)).Replace("-","").ToLower();                
            }
        }

    }
}

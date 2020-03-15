using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace TestAppService
{
    public static class Crypto
    {
        public static string Hash(string vaule)
        {
            return Convert.ToBase64String(
                System.Security.Cryptography.SHA256.Create()
                .ComputeHash(Encoding.UTF8.GetBytes(vaule))
                );
        }
    }
}
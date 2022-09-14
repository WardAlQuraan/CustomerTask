using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CUSTOMER.SERVICES.Services
{
    public static class Hashing
    {
        public static string HashPassword(string password)
        {
            using (var sha = new SHA512CryptoServiceProvider())
            {
                byte[] hashed = sha.ComputeHash(Encoding.Default.GetBytes(password));
                string output = Convert.ToBase64String(hashed);
                return output;
            }
        }
    }
}

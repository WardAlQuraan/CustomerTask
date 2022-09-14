using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUSTOMER.SERVICES.Services
{
    public static class GetErrors
    {
        public static string GenerateErrorMessage(string errorCode)
        {
            switch (errorCode)
            {
                case "-2146232060": return "this username already exist";
                default: return "unknown error";
            }
        }
    }
}

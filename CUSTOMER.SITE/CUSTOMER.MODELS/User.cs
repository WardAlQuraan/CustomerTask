using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUSTOMER.MODELS
{
    public class User
    {
        public int UserId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }

        public String UserName { get; set; }
        public String Role { get; set; }
        public String Password { get; set; }
    }
}

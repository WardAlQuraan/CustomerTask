using System.Web;
using System.Web.Mvc;

namespace CUSTOMER.BACKEND
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

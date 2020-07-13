using System.Web;
using System.Web.Mvc;

namespace Minimal_Reproduction_Bug___131
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

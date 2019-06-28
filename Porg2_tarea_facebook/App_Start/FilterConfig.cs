using System.Web;
using System.Web.Mvc;

namespace Porg2_tarea_facebook
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

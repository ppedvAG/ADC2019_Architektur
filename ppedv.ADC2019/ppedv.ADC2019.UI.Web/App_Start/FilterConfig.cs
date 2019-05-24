using System.Web;
using System.Web.Mvc;

namespace ppedv.ADC2019.UI.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

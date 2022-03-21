using System.Web;
using System.Web.Mvc;

namespace Car_Rent_All
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //Saját hozzáadottak
            filters.Add(new AuthorizeAttribute());

            filters.Add(new HandleErrorAttribute());
        }
    }
}

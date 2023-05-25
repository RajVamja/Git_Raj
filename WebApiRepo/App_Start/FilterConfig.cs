using System.Web;
using System.Web.Mvc;

namespace WebApiRepo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public class SessionEnd : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                if (HttpContext.Current.Session["uIdS"] == null)
                {
                    filterContext.Result = new RedirectResult("~/User/Login");
                }
            }
        }
    }
}

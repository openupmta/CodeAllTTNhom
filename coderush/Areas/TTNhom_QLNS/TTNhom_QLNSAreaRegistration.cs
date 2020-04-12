using System.Web.Mvc;

namespace coderush.Areas.TTNhom_QLNS
{
    public class TTNhom_QLNSAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TTNhom_QLNS";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TTNhom_QLNS_default",
                "TTNhom_QLNS/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
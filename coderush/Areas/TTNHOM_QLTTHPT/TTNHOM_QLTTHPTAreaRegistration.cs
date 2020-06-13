using System.Web.Mvc;

namespace coderush.Areas.TTNhom_QLTTHPT
{
    public class TTNhom_QLTTHPTAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TTNhom_QLTTHPT";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TTNhom_QLTTHPT_default",
                "TTNhom_QLTTHPT/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
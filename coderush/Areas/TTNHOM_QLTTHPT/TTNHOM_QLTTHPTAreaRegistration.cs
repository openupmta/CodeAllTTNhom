using System.Web.Mvc;

namespace coderush.Areas.TTNHOM_QLTTHPT
{
    public class TTNHOM_QLTTHPTAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TTNHOM_QLTTHPT";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TTNHOM_QLTTHPT_default",
                "TTNHOM_QLTTHPT/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
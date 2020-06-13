using System.Web.Mvc;

namespace coderush.Areas.TTNhom_QLKHO
{
    public class TTNhom_QLKHOAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TTNhom_QLKHO";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TTNhom_QLKHO_default",
                "TTNhom_QLKHO/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
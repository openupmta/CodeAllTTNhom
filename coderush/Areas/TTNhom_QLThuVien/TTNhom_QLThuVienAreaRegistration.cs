using System.Web.Mvc;

namespace coderush.Areas.TTNhom_QLThuVien
{
    public class TTNhom_QLThuVienAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TTNhom_QLThuVien";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TTNhom_QLThuVien_default",
                "TTNhom_QLThuVien/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
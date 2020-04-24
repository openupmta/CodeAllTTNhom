﻿using System.Web.Mvc;

namespace coderush.Areas.TTNhon_QLKS
{
    public class TTNhon_QLKSAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TTNhom_QLKS";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TTNhom_QLKS_default",
                "TTNhom_QLKS/{controller}/{action}/{id}",
                new {action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
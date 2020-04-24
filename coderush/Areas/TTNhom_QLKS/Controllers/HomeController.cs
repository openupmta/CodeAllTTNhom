using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace coderush.Areas.TTNhon_QLKS.Controllers
{
    public class HomeController : BaseController
    {
        // GET: TTNhon_QLKS/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}
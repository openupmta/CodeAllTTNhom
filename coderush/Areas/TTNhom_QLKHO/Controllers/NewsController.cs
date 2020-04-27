using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace coderush.Areas.TTNhom_QLKHO.Controllers
{
    public class NewsController : Controller
    {
        // GET: TTNhom_QLKHO/News
        public ActionResult Index()
        {
            return View();
        }
    }
}
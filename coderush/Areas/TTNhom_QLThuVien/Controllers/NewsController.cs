using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace coderush.Areas.TTNhom_QLThuVien.Controllers
{
    public class NewsController : Controller
    {
        // GET: TTNhom_QLThuVien/News
        public ActionResult Index()
        {
            return View();
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using coderush.Areas.TTNHOM_QLTTHPT.Models.Model;

namespace coderush.Areas.TTNHOM_QLTTHPT.Controllers
{
    public class DiemController : Controller
    {
        QuanLyTTHPTContext db = new QuanLyTTHPTContext();

        // GET: TTNHOM_QLTTHPT/Diem
        public ActionResult Index()
        {
            List<DIEM> res = db.DIEMs.ToList();
            return View(res);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using coderush.Areas.TTNhom_QLKS.Dom;
using coderush.Areas.TTNhom_QLKS.EF;

namespace coderush.Areas.TTNhom_QLKS.Controllers
{
    public class DichVuChungsController : Controller
    {
        private QLKSdbContext db = new QLKSdbContext();

        // GET: TTNhom_QLKS/DichVuChungs
        public ActionResult Index()
        {
            return View(db.DichVuChungs.ToList());
        }

        // GET: TTNhom_QLKS/DichVuChungs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DichVuChung dichVuChung = db.DichVuChungs.Find(id);
            if (dichVuChung == null)
            {
                return HttpNotFound();
            }
            return View(dichVuChung);
        }

        // GET: TTNhom_QLKS/DichVuChungs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TTNhom_QLKS/DichVuChungs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maDVC,tenDVC,giaDVC,donvitinhDVC,trangthaiDVC")] DichVuChung dichVuChung)
        {
            if (ModelState.IsValid)
            {
                db.DichVuChungs.Add(dichVuChung);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dichVuChung);
        }

        // GET: TTNhom_QLKS/DichVuChungs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DichVuChung dichVuChung = db.DichVuChungs.Find(id);
            if (dichVuChung == null)
            {
                return HttpNotFound();
            }
            return View(dichVuChung);
        }

        // POST: TTNhom_QLKS/DichVuChungs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maDVC,tenDVC,giaDVC,donvitinhDVC,trangthaiDVC")] DichVuChung dichVuChung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dichVuChung).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dichVuChung);
        }

        // GET: TTNhom_QLKS/DichVuChungs/Delete/5
       
        [HttpDelete]
        public ActionResult Delete(int? id)
        {

            new DichVuChungDom().Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

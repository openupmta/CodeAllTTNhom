using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using coderush.Areas.TTNhom_QLNS.Models;


namespace coderush.Areas.TTNhom_QLNS.Controllers
{
    public class group_roleController : BaseController
    {
        DBQLNSContext db = new DBQLNSContext();

        // GET: TTNhom_QLNS/group_role
        public ActionResult Index()
        {
            return View(db.group_role.ToList());
        }

        // GET: TTNhom_QLNS/group_role/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            group_role group_role = db.group_role.Find(id);
            if (group_role == null)
            {
                return HttpNotFound();
            }
            return View(group_role);
        }

        // GET: TTNhom_QLNS/group_role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TTNhom_QLNS/group_role/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "gr_id,gr_name,gr_description,gr_status")] group_role group_role)
        {
            if (ModelState.IsValid)
            {
                db.group_role.Add(group_role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(group_role);
        }

        // GET: TTNhom_QLNS/group_role/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            group_role group_role = db.group_role.Find(id);
            if (group_role == null)
            {
                return HttpNotFound();
            }
            return View(group_role);
        }

        // POST: TTNhom_QLNS/group_role/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "gr_id,gr_name,gr_description,gr_status")] group_role group_role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(group_role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(group_role);
        }

        public ActionResult Delete(int? id)
        {
            group_role group_role = db.group_role.Find(id);
            db.group_role.Remove(group_role);
            db.SaveChanges();
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

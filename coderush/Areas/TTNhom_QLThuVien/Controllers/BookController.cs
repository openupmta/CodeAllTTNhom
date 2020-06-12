using coderush.Areas.TTNhom_QLThuVien.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace coderush.Areas.TTNhom_QLThuVien.Controllers
{
    public class BookController : Controller
    {
        DBQLTVContext db = new DBQLTVContext();

        // GET: TTNhom_QLThuVien/Book
        public ActionResult Index()
        {
            return View(db.Saches.ToList());
        }

        // GET: TTNhom_QLThuVien/Book/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach obj = db.Saches.Find(id);
            if (obj == null)
            {
                return HttpNotFound();
            }
            return View(obj);
        }

        // GET: TTNhom_QLThuVien/Book/Create
        public ActionResult Create()
        {
            List<TacGia> author = db.TacGias.ToList();
            List<TheLoai> category = db.TheLoais.ToList();
            List<NhaXuatBan> publish = db.NhaXuatBans.ToList();
            SelectList authorList = new SelectList(author, "MaTacGia", "TenTacGia", "MaTacGia");
            SelectList categoryList = new SelectList(category, "MaTheLoai", "TenTheLoai", "MaTheLoai");
            SelectList publishList = new SelectList(publish, "MaNXB", "TenNXB", "MaNXB");
            ViewBag.AuthorList = authorList;
            ViewBag.CategoryList = categoryList;
            ViewBag.PublishList = publishList;
            return View();
        }

        // POST: TTNhom_QLThuVien/Book/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSach, TenSach, MaTacGia, MaTheLoai, MaNXB, NamXuatBan, TinhTrang")] Sach obj)
        {
            if (ModelState.IsValid)
            {
                db.Saches.Add(obj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        // GET: TTNhom_QLThuVien/Book/Edit/5
        public ActionResult Edit(string id)
        {
            List<TacGia> author = db.TacGias.ToList();
            List<TheLoai> category = db.TheLoais.ToList();
            List<NhaXuatBan> publish = db.NhaXuatBans.ToList();
            SelectList authorList = new SelectList(author, "MaTacGia", "TenTacGia", "MaTacGia");
            SelectList categoryList = new SelectList(category, "MaTheLoai", "TenTheLoai", "MaTheLoai");
            SelectList publishList = new SelectList(publish, "MaNXB", "TenNXB", "MaNXB");
            ViewBag.AuthorList = authorList;
            ViewBag.CategoryList = categoryList;
            ViewBag.PublishList = publishList;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sach obj = db.Saches.Find(id);
            if (obj == null)
            {
                return HttpNotFound();
            }
            return View(obj);
        }

        // POST: TTNhom_QLThuVien/Book/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSach, TenSach, MaTacGia, MaTheLoai, MaNXB, NamXuatBan, TinhTrang")] Sach obj)
        {
            if (ModelState.IsValid)
            {
                db.Entry(obj).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public ActionResult Delete(string id)
        {
            try
            {
                Sach obj = db.Saches.Find(id);
                db.Saches.Remove(obj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        public ActionResult AddAuthor()
        {
            return View("AddAuthor");
        }

        public ActionResult AddCategory()
        {
            return View("AddCategory");
        }

        public ActionResult AddPublishingCompany()
        {
            return View("AddPublishingCompany");
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
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using coderush.Areas.TTNhom_QLNS.Models;
using coderush.Areas.TTNhom_QLNS.Models.Staff;
using Common;

namespace coderush.Areas.TTNhom_QLNS.Controllers
{
    public class StaffsController : Controller
    {
        private DBQLNSContext db = new DBQLNSContext();

        // GET: TTNhom_QLNS/Staffs
        public ActionResult Index()
        {
            var staffs = db.staffs.Include(s => s.department).Include(s => s.group_role).Include(s => s.position);
            return View(staffs.ToList());
        }

        // GET: TTNhom_QLNS/Staffs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            staff staff = db.staffs.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // GET: TTNhom_QLNS/Staffs/Create
        public ActionResult Create()
        {
            ViewBag.department_id = new SelectList(db.departments, "de_id", "de_name");
            ViewBag.group_role_id = new SelectList(db.group_role, "gr_id", "gr_name");
            ViewBag.position_id = new SelectList(db.positions, "pos_id", "pos_name");
            ViewBag.provinceID = new SelectList(db.Provinces, "Id", "Name", db.Provinces.FirstOrDefault().Id);
            ViewBag.districtID = new SelectList(db.Districts, "Id", "Name", db.Districts.FirstOrDefault().Id);
            ViewBag.wardID = new SelectList(db.Wards, "Id", "Name", db.Wards.FirstOrDefault().Id);
            return View();
        }

        // POST: TTNhom_QLNS/Staffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(staff staff,AddressViewModel address)
        {
            if (ModelState.IsValid)
            {
                //Save infor staff
                var code = db.staffs.OrderByDescending(x => x.sta_id).FirstOrDefault();
                if (code == null) staff.sta_code = "NV000001";
                else staff.sta_code = Utilis.CreateCodeByCode("NV", code.sta_code, 8);
                staff.sta_created_date = DateTime.Now;
                //Mail 
                string content = System.IO.File.ReadAllText("D:/Ki2Nam3/ttn/Tien_TTNhom/CodeAllTTNhom/Common/Template/sendmail.html");
                content = content.Replace("{{Username}}", staff.sta_username);
                content = content.Replace("{{Password}}", staff.sta_password);

                new MailHelper().SendMail(staff.sta_email, "Thông tin tài khoản", content);
                db.staffs.Add(staff);

                db.SaveChanges();
                //Save address of staff 
                
                staff staff_last = db.staffs.OrderByDescending(x => x.sta_id).FirstOrDefault();
                address create_add = new address();
                create_add.add_province = db.Provinces.Where(x => x.Id == address.provinceID).FirstOrDefault().Name;
                create_add.add_district = db.Districts.Where(x => x.Id == address.districtID).FirstOrDefault().Name;
                create_add.add_ward = db.Wards.Where(x => x.Id == address.wardID).FirstOrDefault().Name;
                create_add.staff_id = staff_last.sta_id;
                db.addresses.Add(create_add);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.department_id = new SelectList(db.departments, "de_id", "de_name", staff.department_id);
            ViewBag.group_role_id = new SelectList(db.group_role, "gr_id", "gr_name", staff.group_role_id);
            ViewBag.position_id = new SelectList(db.positions, "pos_id", "pos_name", staff.position_id);
            return View(staff);
        }

        // GET: TTNhom_QLNS/Staffs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            staff staff = db.staffs.Find(id);
            address add = db.addresses.Where(x => x.staff_id == staff.sta_id).FirstOrDefault();
            if (staff == null)
            {
                return HttpNotFound();
            }
            ViewBag.department_id = new SelectList(db.departments, "de_id", "de_name", staff.department_id);
            ViewBag.group_role_id = new SelectList(db.group_role, "gr_id", "gr_name", staff.group_role_id);
            ViewBag.position_id = new SelectList(db.positions, "pos_id", "pos_name", staff.position_id);

            ViewBag.provinceID = new SelectList(db.Provinces, "Id", "Name", db.Provinces.Where(x => x.Name.Contains(add.add_province)).FirstOrDefault().Id);
            ViewBag.districtID = new SelectList(db.Districts, "Id", "Name", db.Districts.Where(x => x.Name.Contains(add.add_district)).FirstOrDefault().Id);
            ViewBag.wardID = new SelectList(db.Wards, "Id", "Name", db.Wards.Where(x => x.Name.Contains(add.add_ward)).FirstOrDefault().Id);
            return View(staff);
        }

        // POST: TTNhom_QLNS/Staffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( staff staff, AddressViewModel address)
        {
            if (ModelState.IsValid)
            {
                staff up_staff = db.staffs.Find(staff.sta_id);
                up_staff.department_id = staff.department_id;
                up_staff.position_id = staff.position_id;
                up_staff.sta_aboutme = staff.sta_aboutme;
                up_staff.sta_birthday = staff.sta_birthday;
                up_staff.sta_email = staff.sta_email;
                up_staff.sta_fullname = staff.sta_fullname;
                up_staff.sta_identity_card = staff.sta_identity_card;
                up_staff.sta_identity_card_date = staff.sta_identity_card_date;
                up_staff.sta_mobile = staff.sta_mobile;
                up_staff.sta_password = staff.sta_password;
                up_staff.sta_sex = staff.sta_sex;
                up_staff.sta_status = staff.sta_status;
                up_staff.sta_thumbnai = staff.sta_thumbnai;
                up_staff.sta_username = staff.sta_username;


                db.Entry(up_staff).State = EntityState.Modified;
                db.SaveChanges();

                address update_add = db.addresses.Where(x => x.staff_id == staff.sta_id).FirstOrDefault();
                update_add.add_province = db.Provinces.Where(x => x.Id == address.provinceID).FirstOrDefault().Name;
                update_add.add_district = db.Districts.Where(x => x.Id == address.districtID).FirstOrDefault().Name;
                update_add.add_ward = db.Wards.Where(x => x.Id == address.wardID).FirstOrDefault().Name;
                db.Entry(update_add).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.department_id = new SelectList(db.departments, "de_id", "de_name", staff.department_id);
            ViewBag.group_role_id = new SelectList(db.group_role, "gr_id", "gr_name", staff.group_role_id);
            ViewBag.position_id = new SelectList(db.positions, "pos_id", "pos_name", staff.position_id);
            ViewBag.provinceID = new SelectList(db.Provinces, "Id", "Name", address.provinceID);
            ViewBag.districtID = new SelectList(db.Districts, "Id", "Name",address.districtID);
            ViewBag.wardID = new SelectList(db.Wards, "Id", "Name", address.wardID);
            return View(staff);
        }

        // GET: TTNhom_QLNS/Staffs/Delete/5
        public ActionResult Delete(int? id)
        {
            staff staff = db.staffs.Find(id);
            db.staffs.Remove(staff);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public JsonResult LoadProvince()
        {
            List<dropdown> res = new List<dropdown>();
            List<Province> lts = db.Provinces.ToList();
            foreach (Province d in lts)
            {
                dropdown dr = new dropdown();
                dr.Id = d.Id;
                dr.Name = d.Name;
                res.Add(dr);
            }
            return Json(new
            {
                data = res,
                status = true
            });
        }
        public JsonResult LoadDistrict(int? provinceID)
        {
            List<dropdown> res = new List<dropdown>();
            List<District> lts = db.Districts.Where(x => x.ProvinceId == provinceID).ToList();
            foreach (District d in lts)
            {
                dropdown dr = new dropdown();
                dr.Id = d.Id;
                dr.Name = d.Name;
                res.Add(dr);
            }
            return Json(new
            {
                data = res,
                status = true
            });
        }
        public JsonResult LoadWard(int? districtID)
        {
            List<dropdown> res = new List<dropdown>();
            List<Ward> lts = db.Wards.Where(x => x.DistrictID == districtID).ToList();
            foreach (Ward d in lts)
            {
                dropdown dr = new dropdown();
                dr.Id = d.Id;
                dr.Name = d.Name;
                res.Add(dr);
            }
            return Json(new
            {
                data = res,
                status = true
            });
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

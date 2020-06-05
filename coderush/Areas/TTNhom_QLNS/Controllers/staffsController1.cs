//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using AutoMapper;
//using coderush.Areas.TTNhom_QLNS.Models;
//using coderush.Areas.TTNhom_QLNS.Models.Staff;
//namespace coderush.Areas.TTNhom_QLNS.Controllers
//{
//    [Authorize]
//    public class staffsController1 : BaseController
//    {
//        private DBQLNSContext db = new DBQLNSContext();


//        // GET: TTNhom_QLNS/staffs
//        [Authorize]
//        public ActionResult Index()
//        {
//            var staffs = db.staffs.ToList();
//            return View(staffs.ToList());
//        }

//        // GET: TTNhom_QLNS/staffs/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            staff staff = db.staffs.Find(id);
//            if (staff == null)
//            {
//                return HttpNotFound();
//            }
//            return View(staff);
//        }

//        // GET: TTNhom_QLNS/staffs/Create
//        public ActionResult Create()
//        {
//            ViewBag.department_id = new SelectList(db.departments, "de_id", "de_name");
//            ViewBag.group_role_id = new SelectList(db.group_role, "gr_id", "gr_name");
//            ViewBag.position_id = new SelectList(db.positions, "pos_id", "pos_name");
//            return View();
//        }

//        // POST: TTNhom_QLNS/staffs/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(StaffCreateViewModel create_staff)
//        {
            
//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    staff staff = Mapper.Map<staff>(create_staff);
//                    var code = db.staffs.OrderByDescending(x => x.sta_id).FirstOrDefault();
//                    if (code == null) staff.sta_code = "NV000001";
//                    else staff.sta_code = Utilis.CreateCodeByCode("NV", code.sta_code, 8);
//                    staff.sta_created_date = DateTime.Now;
//                    db.staffs.Add(staff);

//                    db.SaveChanges();
//                    staff staff_last = db.staffs.OrderByDescending(x => x.sta_id).FirstOrDefault();
//                    address create_add = new address();
//                    create_add.add_province = db.Provinces.Where(x => x.Id == create_staff.provinceID).FirstOrDefault().Name;
//                    create_add.add_district = db.Districts.Where(x => x.Id == create_staff.districtID).FirstOrDefault().Name;
//                    create_add.add_ward = db.Wards.Where(x => x.Id == create_staff.wardID).FirstOrDefault().Name;
//                    create_add.staff_id = staff_last.sta_id;
//                    db.addresses.Add(create_add);
//                    db.SaveChanges();
//                }
//                catch (Exception e)
//                {
//                    Console.WriteLine("{0} Exception caught.", e);
//                }

                
//                return RedirectToAction("Index");
//            }

//            ViewBag.department_id = new SelectList(db.departments, "de_id", "de_name", create_staff.department_id);
//            ViewBag.group_role_id = new SelectList(db.group_role, "gr_id", "gr_name", create_staff.group_role_id);
//            ViewBag.position_id = new SelectList(db.positions, "pos_id", "pos_name", create_staff.position_id);
//            return View();
//        }

//        // GET: TTNhom_QLNS/staffs/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            staff staff = db.staffs.Find(id);
//            address add = db.addresses.Where(x => x.staff_id == staff.sta_id).FirstOrDefault();
//            if (staff == null)
//            {
//                return HttpNotFound();
//            }
//            ViewBag.department_id = new SelectList(db.departments, "de_id", "de_name", staff.department_id);
//            ViewBag.group_role_id = new SelectList(db.group_role, "gr_id", "gr_name", staff.group_role_id);
//            ViewBag.position_id = new SelectList(db.positions, "pos_id", "pos_name", staff.position_id);
            
//            ViewBag.provinceID = new SelectList(db.Provinces, "Id", "Name", db.Provinces.Where(x => x.Name.Contains(add.add_province)).FirstOrDefault().Id);
//            ViewBag.districtID = new SelectList(db.Districts, "Id", "Name", db.Districts.Where(x => x.Name.Contains(add.add_district)).FirstOrDefault().Id);
//            ViewBag.wardID = new SelectList(db.Wards, "Id", "Name", db.Wards.Where(x => x.Name.Contains(add.add_ward)).FirstOrDefault().Id);
//            return View(staff);
//        }

//        // POST: TTNhom_QLNS/staffs/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(StaffUpdateViewModel update_staff)
//        {
//            if (ModelState.IsValid)
//            {
//                staff staff = db.staffs.Find(update_staff.sta_id);
//                staff.department_id = update_staff.department_id;
//                staff.position_id= update_staff.position_id;
//                staff.sta_aboutme = update_staff.sta_aboutme;
//                staff.sta_birthday = update_staff.sta_birthday;
//                staff.sta_email = update_staff.sta_email;
//                staff.sta_fullname = update_staff.sta_fullname;
//                staff.sta_identity_card = update_staff.sta_identity_card;
//                staff.sta_identity_card_date = update_staff.sta_identity_card_date;
//                staff.sta_mobile = update_staff.sta_mobile;
//                staff.sta_password = update_staff.sta_password;
//                staff.sta_sex = update_staff.sta_sex;
//                staff.sta_status = update_staff.sta_status;
//                staff.sta_thumbnai = update_staff.sta_thumbnai;
//                staff.sta_username = update_staff.sta_username;


//                db.Entry(staff).State = EntityState.Modified;
//                db.SaveChanges();

//                address update_add = db.addresses.Where(x => x.staff_id == update_staff.sta_id).FirstOrDefault();
//                update_add.add_province = db.Provinces.Where(x => x.Id == update_staff.provinceID).FirstOrDefault().Name;
//                update_add.add_district = db.Districts.Where(x => x.Id == update_staff.districtID).FirstOrDefault().Name;
//                update_add.add_ward = db.Wards.Where(x => x.Id == update_staff.wardID).FirstOrDefault().Name;
//                db.Entry(update_add).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            ViewBag.department_id = new SelectList(db.departments, "de_id", "de_name", update_staff.department_id);
//            ViewBag.group_role_id = new SelectList(db.group_role, "gr_id", "gr_name", update_staff.group_role_id);
//            ViewBag.position_id = new SelectList(db.positions, "pos_id", "pos_name", update_staff.position_id);
//            staff staff1 = Mapper.Map<staff>(update_staff);
//            return View(staff1);
//        }

//        // GET: TTNhom_QLNS/staffs/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            staff staff = db.staffs.Find(id);
//            db.staffs.Remove(staff);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }


        
//        public JsonResult LoadProvince()
//        {
//            List<dropdown> res = new List<dropdown>();
//            List<Province> lts = db.Provinces.ToList();
//            foreach (Province d in lts)
//            {
//                dropdown dr = new dropdown();
//                dr.Id = d.Id;
//                dr.Name = d.Name;
//                res.Add(dr);
//            }
//            return Json(new
//            {
//                data = res,
//                status = true
//            });
//        }
//        public JsonResult LoadDistrict(int? provinceID)
//        {
//            List<dropdown> res = new List<dropdown>();
//            List<District> lts = db.Districts.Where(x => x.ProvinceId == provinceID).ToList();
//            foreach(District d in lts)
//            {
//                dropdown dr = new dropdown();
//                dr.Id = d.Id;
//                dr.Name = d.Name;
//                res.Add(dr);
//            }
//            return Json(new
//            {
//                data = res,
//                status = true
//            });
//        }
//        public JsonResult LoadWard(int? districtID)
//        {
//            List<dropdown> res = new List<dropdown>();
//            List<Ward> lts = db.Wards.Where(x => x.DistrictID == districtID).ToList();
//            foreach(Ward d in lts)
//            {
//                dropdown dr = new dropdown();
//                dr.Id = d.Id;
//                dr.Name = d.Name;
//                res.Add(dr);
//            }
//            return Json(new
//            {
//                data = res,
//                status = true
//            });
//         }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}

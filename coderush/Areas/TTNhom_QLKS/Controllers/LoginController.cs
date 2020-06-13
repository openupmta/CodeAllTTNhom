using coderush.Areas.TTNhom_QLKS.Dom;
using coderush.Areas.TTNhom_QLKS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace coderush.Areas.TTNhom_QLKS.Controllers
{
    public class LoginController : Controller
    {
        // GET: admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDom();
                var result = dao.Login(collection["inputUserName"].ToString(), collection["UserPassword"].ToString());
                if (result == 1)
                {
                    var user = dao.GetById(collection["inputUserName"].ToString());
                    var userSession = new UserLogin();
                    userSession.UserName = user.Username;
                    userSession.UserID = user.ID;

                    Session.Add(CommonConstants.USER_SESSION, userSession.UserName);
                    Session.Add(CommonConstants.ID_SESSION, userSession.UserID);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Account isn't exist");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Account is locked");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Password is wronged");
                }
                else
                {
                    ModelState.AddModelError("", "đăng nhập không đúng");
                }
            }
            else
            {

            }
            return View("Index");
        }


        //

    }
}
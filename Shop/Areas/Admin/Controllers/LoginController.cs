using Models.DAO;
using Shop.Areas.Admin.Models;
using Shop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModels model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var result = dao.Login(model.UserName, model.Password);
                if (result)
                {
                    var user = dao.GetByString(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.ID;

                    Session.Add(CommonContants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập ko đúng.");
                }
            }
            return View("Index");
        }
    }
}
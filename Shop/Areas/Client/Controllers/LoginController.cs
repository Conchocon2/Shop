using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models.DAO;
using System.Web.Mvc;
using Shop.Areas.Client.Models;
using Shop.Common;
using static Shop.Common.CommonContants;

namespace Shop.Areas.Client.Controllers {
    public class LoginController : Controller {

        public ActionResult Index() {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model) {
            UserDAO dao = new UserDAO();
            bool login = dao.Login(model.UserName, model.PassWord);
            if (login) {
                UserLogin userLogin = new UserLogin { UserName = model.UserName, RightCode = 1 };
                if (model.RememberMe) {
                    HttpCookie cookie1 = new HttpCookie(USER_SESSION, userLogin.UserName);
                    HttpCookie cookie2 = new HttpCookie(RIGHT_CODE, userLogin.RightCode.ToString());
                    Request.Cookies.Add(cookie1);
                    Request.Cookies.Add(cookie2);
                } else {
                    Session.Add(USER_SESSION, userLogin);
                }
            } else {
                return RedirectToAction("Login");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Login() {
            return View();
        }
    }
}
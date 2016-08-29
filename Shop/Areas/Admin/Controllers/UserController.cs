using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(string searchString, int page = 1, int pageSize = 3)
        {
            var dao = new UserDAO();
            var model = dao.ListAllPage(searchString, page, pageSize);
            ViewBag.searchString = searchString;
            return View(model);
        }
        #region[Create]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult Create(User inputModel)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                long id = dao.Insert(inputModel);
                if (id > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm ko thành công");
                }
            }
            SetViewBag(inputModel.MaChucVu);
            return View("Create");
        }
        #endregion
        #region[Edit]
        public ActionResult Edit (int id)
        {
            var model = new UserDAO().GetByID(id);
            SetViewBag();
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(User inputModel)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDAO();
                var capnhat = dao.Update(inputModel);
                if (capnhat)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật ko thành công");
                }
            }
            SetViewBag(inputModel.MaChucVu);
            return View("Edit");
        }
        #endregion
        #region[Delete]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            new UserDAO().Delete(id);
            return RedirectToAction("Index");
        }
        #endregion
        public void SetViewBag(long? selectedID = null)
        {
            var dao = new PosisionDAO();
            ViewBag.MaChucVu = new SelectList(dao.ListPosision(), "MaChucVu", "TenChucVu", selectedID);
        }
    }
}
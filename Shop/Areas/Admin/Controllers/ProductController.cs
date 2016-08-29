using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var dao = new ProductDAO();
            var model = dao.ListAll(searchString, page, pageSize);
            ViewBag.searchString = searchString;
            return View(model);
        }
        #region[Create]
        public ActionResult Create()
        {
            SetCate();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Product inputModel)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDAO();
                long id = dao.Insert(inputModel);
                if (id > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm SP ko thành công");
                }
            }
            SetCate(inputModel.Cate_ID);
            return View("Create");
        }
        #endregion
        #region[Edit]
        public ActionResult Edit(int id)
        {
            var model = new ProductDAO().GetByID(id);
            SetCate();
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Product sanpham)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDAO();
                var update = dao.Update(sanpham);
                if (update)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            return View("Edit");
        }
        #endregion
        #region[Delete
        [HttpPost]
        public ActionResult Delete(int id)
        {
            new ProductDAO().Delete(id);
            return RedirectToAction("Index");
        }
        #endregion
        public void SetCate(long? cateID = null)
        {
            var dao = new CategoryDAO();
            ViewBag.Cate_ID = new SelectList(dao.ListLoaiSP(), "ID", "CateName", cateID);
        }
    }
}
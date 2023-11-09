using WebClothing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebClothing.Controllers
{
    public class CategoryManageController : Controller
    {
        // GET: CategoryManage
        DBWebClothingEntities db = new DBWebClothingEntities();
        public ActionResult Index()
        {
            //if (CheckRole("Admin"))
            //{

            //}
            //else
            //{
            //    return
            //    RedirectToAction("Index", "Admin");
            //}

            var categories = db.Categories.ToList();
            return View(categories);
        }

        //public ActionResult ToggleActive(int ID)
        //{
        //    Category category = db.Categories.Find(ID);
        //    category.IsActive = !category.IsActive;
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        public ActionResult Details(int ID)
        {
            //if (CheckRole("Admin"))
            //{

            //}
            //else
            //{
            //    return RedirectToAction("Index", "Admin");
            //}
            Category category = db.Categories.Find(ID);
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            Category categoryUpdate = db.Categories.Find(category.ID);
            categoryUpdate.Name = category.Name;
            db.SaveChanges();
            ViewBag.Message = "Cập nhật thành công";
            return View("Details", categoryUpdate);
        }
        public ActionResult Edit()
        {
            return RedirectToAction("Index");
        }

        public ActionResult Add()
        {
            //if (CheckRole("Admin"))
            //{

            //}
            //else
            //{
            //    return RedirectToAction("Index", "Admin");
            //}
            return View();
        }
        [HttpPost]
        public ActionResult Add(Category category)
        {
            //category.IsActive = true;
            Category cate = db.Categories.Add(category);
            db.SaveChanges();
            ViewBag.Message = "Thêm thành công";
            return RedirectToAction("Index");
        }
        public ActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int? ID)
        {
            Category category = db.Categories.Find(ID);
            db.Categories.Remove(category);
            db.SaveChanges();
            ViewBag.Message = "Xoá thành công";
            return RedirectToAction("Index");
        }

    }
}
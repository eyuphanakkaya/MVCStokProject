using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category


        MvcProjeEntities Db = new MvcProjeEntities();
        public ActionResult Index()
        {
            var Degerler = Db.TbCategory.ToList();
            return View(Degerler);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(TbCategory P1)
        {
            if (!ModelState.IsValid)
            {
                return View("AddCategory");
            }
            Db.TbCategory.Add(P1);
            Db.SaveChanges();
            return RedirectToAction("AddCategory");
        }

        public ActionResult DeleteCategory(int Id)
        {
            var Deger = Db.TbCategory.Find(Id);
            Db.TbCategory.Remove(Deger);
            Db.SaveChanges();
           return  RedirectToAction("Index");
        }

        public ActionResult GetCategory(int Id)
        {
            var Ktg=Db.TbCategory.Find(Id);
            return View("GetCategory", Ktg);

        }

        public ActionResult UpdateCategory(TbCategory P1)
        {
           var Ktg = Db.TbCategory.Find(P1.CategoryId);
            Ktg.CategoryName = P1.CategoryName;
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        MvcProjeEntities Db = new MvcProjeEntities();
        public ActionResult Index()
        {
            var Degerler = Db.TbProduct.ToList();
            return View(Degerler);
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            List<SelectListItem> Degerler = (from x in Db.TbCategory.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryId.ToString()
                                             }).ToList();
            ViewBag.Dgr = Degerler;
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(TbProduct P1)
        {
           
            var Ktg = Db.TbCategory.Where(m => m.CategoryId == P1.TbCategory.CategoryId).FirstOrDefault();
            P1.TbCategory = Ktg;
            Db.TbProduct.Add(P1);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult DeleteProduct(int Id)
        {
            var Deger=Db.TbProduct.Find(Id);
            Db.TbProduct.Remove(Deger);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetProduct(int Id)
        {
            var Urn = Db.TbProduct.Find(Id);
            List<SelectListItem> Degerler = (from x in Db.TbCategory.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryId.ToString()
                                             }).ToList();
            ViewBag.Dgr = Degerler;
            return View("GetProduct", Urn);
        }
        public ActionResult UpdateProduct(TbProduct P1)
        {
            var Urun = Db.TbProduct.Find(P1.ProductId);
            Urun.ProductId = P1.ProductId;
            Urun.ProductName = P1.ProductName;
            var Ktg = Db.TbCategory.Where(m => m.CategoryId == P1.TbCategory.CategoryId).FirstOrDefault();
            Urun.ProductCategory = Ktg.CategoryId;
            Urun.Price = P1.Price;
            Db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
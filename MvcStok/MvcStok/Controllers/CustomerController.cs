using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        MvcProjeEntities Db = new MvcProjeEntities();
        public ActionResult Index()
        {
            var Degerler = Db.TbCustomer.ToList();
            return View(Degerler);
        }
        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public  ActionResult AddCustomer(TbCustomer P1)
        {
            if (!ModelState.IsValid)
            {
               return View("AddCustomer");
            }
            Db.TbCustomer.Add(P1);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCustomer(int Id)
        {
            var Deger=Db.TbCustomer.Find(Id);
            Db.TbCustomer.Remove(Deger);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetCustomer(int Id)
        {
            var Mstr = Db.TbCustomer.Find(Id);
            return View("GetCustomer", Mstr);

        }
        public ActionResult UpdateCustomer(TbCustomer P1)
        {
            var Mustr = Db.TbCustomer.Find(P1.CustomerId);
            Mustr.CustomerName = P1.CustomerName;
            Mustr.CustomerLastName = P1.CustomerLastName;
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
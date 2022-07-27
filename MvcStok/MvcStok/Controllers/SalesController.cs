using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        MvcProjeEntities Db = new MvcProjeEntities();
        public ActionResult Index()
        {
           
            return View();
        }
        [HttpGet]
        public ActionResult ForSale()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForSale(TbSales P1)
        {
            Db.TbSales.Add(P1);
            Db.SaveChanges();
            return View("Index");
        }
       
    }
}
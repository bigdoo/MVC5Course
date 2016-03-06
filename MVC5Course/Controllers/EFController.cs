using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class EFController : Controller
    {
        FabricsEntities db = new FabricsEntities();

        public ActionResult Index()
        {
            var product = new Product()
            {
                ProductName = "BMW",
                Price = 2,
                Stock = 1,
                Active = true
            };

            db.Product.Add(product);

            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult item in ex.EntityValidationErrors)
                {
                    string entityName = item.Entry.Entity.GetType().Name;

                    foreach (DbValidationError err in item.ValidationErrors)
                    {
                        throw new Exception(entityName + " 類型驗證失敗: " + err.ErrorMessage);
                    }
                }
                throw;
            }

            var pkey = product.ProductId;

            //var data = db.Product.Where(p => p.ProductId == pkey).ToList();

            var data = db.Product.OrderByDescending(p => p.ProductId);

            return View(data);
        }

        public ActionResult Detail(int id)
        {
            //var data = db.Product.Find(id);
            //var data = db.Product.Where(p => p.ProductId == id).FirstOrDefault();
            var data = db.Product.FirstOrDefault(p => p.ProductId == id);

            return View(data);
        }
    }
}
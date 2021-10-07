using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReviewMVCC_Core.Models;

namespace ReviewMVCC_Core.Controllers
{
    public class ProductController : Controller
    {
        ReviewDBContext db = new ReviewDBContext();

        public IActionResult ViewAll()
        {
            return View(db.Products.ToList());
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            var productEdit = db.Products.SingleOrDefault(p => p.Id == id);
            return View(productEdit);
        }

        [HttpPost]
        public IActionResult Edit(Product pro)
        {
            var productEdit = db.Products.SingleOrDefault(p => p.Id == pro.Id);
            productEdit.PictureUrl = pro.PictureUrl;
            productEdit.ProductName = pro.ProductName;
            productEdit.Price = pro.Price;
            db.SaveChanges();
            return RedirectToAction("ViewAll");
        }

        [HttpPost]
        public IActionResult Create(Product pro)
        {
            if(pro.ProductName == null || pro.ProductName.Length <= 3)
            {
                ModelState.AddModelError("ProductName", "Ten SP phai >3 ky tu!");
                return View();
            }
            else
            {
                db.Products.Add(pro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }           
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}

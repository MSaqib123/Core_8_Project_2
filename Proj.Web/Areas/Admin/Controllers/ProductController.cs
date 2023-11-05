using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Proj.DataAccess.Data;
using Proj.DataAccess.Repository.IRepository;
using Proj.Models;

namespace Proj.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _iUnit;
        public ProductController(IUnitOfWork iUnit)
        {
            _iUnit = iUnit;
        }
        public IActionResult Index()
        {
            var catList = _iUnit.Product.GetAll();
            return View(catList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Product obj = new Product();
            return View(obj);
        }
        
        [HttpPost]
        public IActionResult Create(Product obj)
        {
            if (ModelState.IsValid)
            {
                _iUnit.Product.Add(obj);
                _iUnit.SaveChange();
                TempData["Success"] = "Inserted Successfuly";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? obj = _iUnit.Product.Get(x => x.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        
        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Id > 0)
                {
                    _iUnit.Product.Update(obj);
                    _iUnit.SaveChange();
                    TempData["Success"] = "Updated Successfuly";
                    return RedirectToAction("Index");
                }
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? obj = _iUnit.Product.Get(x => x.Id == id);
            _iUnit.Product.Remove(obj);
            _iUnit.SaveChange();
            TempData["Success"] = "Deleted Successfuly";
            return RedirectToAction("Index");
        }

    }
}

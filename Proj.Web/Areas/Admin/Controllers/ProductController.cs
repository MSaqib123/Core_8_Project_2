using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proj.DataAccess.Data;
using Proj.DataAccess.Repository.IRepository;
using Proj.Models;
using Proj.Models.ViewModel;

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
            IEnumerable<SelectListItem> categoryList = _iUnit.Category.GetAll().Select(x=>new SelectListItem 
                { 
                    Text = x.Name,
                    Value = x.CategoryId.ToString()
                });

            //________ ViewBag ___________
            //ViewBag.CategoryList = categoryList;

            //________ ViewData ___________
            //ViewData["CategoryList"] = categoryList;

            //________ ViewModel ___________
            ProductVM vm = new ProductVM();
            vm.categoryList_obj = categoryList;
            vm.Product_obj = obj;

            //return View(obj);
            return View(vm);
        }
        
        [HttpPost]
        public IActionResult Create(ProductVM vm)
        {
            if (ModelState.IsValid)
            {
                if (vm.Product_obj.ImageUrl == null)
                {
                    vm.Product_obj.ImageUrl = "";
                }
                _iUnit.Product.Add(vm.Product_obj);
                _iUnit.SaveChange();
                TempData["Success"] = "Inserted Successfuly";
                return RedirectToAction("Index");
            }
            return View(vm);
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

            IEnumerable<SelectListItem> categoryList = _iUnit.Category.GetAll().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.CategoryId.ToString()
            });

            ProductVM vm = new ProductVM();
            vm.categoryList_obj = categoryList;
            vm.Product_obj = obj;

            return View(vm);
        }
        
        [HttpPost]
        public IActionResult Edit(ProductVM vm)
        {
            if (ModelState.IsValid)
            {
                if (vm.Product_obj.Id > 0)
                {
                    if (vm.Product_obj.ImageUrl == null)
                    {
                        vm.Product_obj.ImageUrl = "";
                    }
                    _iUnit.Product.Update(vm.Product_obj);
                    _iUnit.SaveChange();
                    TempData["Success"] = "Updated Successfuly";
                    return RedirectToAction("Index");
                }
            }
            return View(vm);
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

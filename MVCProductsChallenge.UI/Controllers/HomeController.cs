using MVCProductsChallenge.Model.Entities;
using MVCProductsChallenge.Services;
using MVCProductsChallenge.UI.ViewModels.HomeViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProductsChallenge.UI.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IProductService _productService;
        private readonly IProductTypeService _productTypeService;

        public HomeController()
        {
            _productService = new ProductService();
            _productTypeService = new ProductTypeService();
        }

        public ActionResult Index()
        {
            var products = _productService
                .List()
                .Include(x => x.ProductType)
                .ToList();
            var productTypes = _productTypeService
                .List()
                .OrderBy(x => x.ProductTypeName)
                .ToList();

            var viewModel = new IndexViewModel
            {
                Title = "Products",
                NewProduct = new Product(),
                Products = products,
                ProductTypes = productTypes
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CreateProduct([Bind(Include = "NewProduct.Description,NewProduct.Price")] IndexViewModel model)
        {
            if (ModelState.IsValid)
            {
                
            }

            return RedirectToAction("Index");
        }
    }
}
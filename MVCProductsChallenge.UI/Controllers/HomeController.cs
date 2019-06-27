﻿using MVCProductsChallenge.Model.Entities;
using MVCProductsChallenge.Services;
using MVCProductsChallenge.UI.ViewModels.HomeViewModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace MVCProductsChallenge.UI.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IProductService _productService;

        public HomeController()
        {
            _productService = new ProductService();
        }

        public ActionResult Index()
        {
            var products = _productService
                .List()
                .Include(x => x.ProductType)
                .ToList();

            ViewBag.Title = "Products";

            var viewModel = new IndexViewModel
            {
                Products = products
            };

            return View(viewModel);
        }

        public ActionResult CreateProduct()
        {
            ViewBag.Title = "Create product";

            return View(new Product());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitCreateProduct([Bind(Include = "Description,Price,ProductTypeId")] Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Create(product);
                return RedirectToAction("Index");
            }

            return View("CreateProduct", product);
        }

        public ActionResult EditProduct(int productId)
        {
            ViewBag.Title = "Edit product";

            var selectedProduct = _productService.Get(productId);
            return View("EditProduct", selectedProduct);
        }

        [HttpPost]
        public ActionResult SubmitEditProduct([Bind(Include = "Description,Price,ProductTypeId,ProductStatus")] Product product)
        {
            if (ModelState.IsValid)
            {
                var oldProduct = _productService.Get(product.Id);
                _productService.Update(oldProduct, product);
                return RedirectToAction("Index");
            }

            return View("CreateProduct", product);
        }
    }
}
using MVCProductsChallenge.Model.Entities;
using MVCProductsChallenge.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProductsChallenge.UI.Controllers
{
    public class ProductTypeController : Controller
    {
        private readonly IProductTypeService _productTypeService;

        public ProductTypeController()
        {
            _productTypeService = new ProductTypeService();
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Product types";

            ViewBag.ProductTypes = _productTypeService
                .List()
                .OrderBy(x => x.Name)
                .ToList();

            return View();
        }

        //[HttpPost]
        //public ActionResult GetProducts(string identifier, string description)
        //{
        //    if (string.IsNullOrWhiteSpace(identifier))
        //        identifier = null;

        //    if (string.IsNullOrWhiteSpace(description))
        //        description = null;

        //    var products = _productService
        //        .List()
        //        .Include(x => x.ProductType)
        //        .Where(x => (identifier == null || x.Identifier == identifier) && (description == null || x.Description.ToLower().Contains(description.ToLower())))
        //        .ToList();

        //    return PartialView("ProductsTable", products);
        //}

        public ActionResult CreateProductType()
        {
            ViewBag.Title = "Create product type";

            return View(new ProductType());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitCreateProductType([Bind(Include = "Name")] ProductType productType)
        {
            if (ModelState.IsValid)
            {
                _productTypeService.Create(productType);
                return RedirectToAction("Index");
            }

            return View("CreateProductType", productType);
        }

        public ActionResult EditProductType(int productTypeId)
        {
            ViewBag.Title = "Edit product type";

            var selectedProductType = _productTypeService.Get(productTypeId);
            return View("EditProductType", selectedProductType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitEditProductType([Bind(Include = "Id,Name")] ProductType productType)
        {
            if (ModelState.IsValid)
            {
                var oldProductType = _productTypeService.Get(productType.Id);
                _productTypeService.Update(oldProductType, productType);
                return RedirectToAction("Index");
            }

            return View("EditProductType", productType);
        }
    }
}
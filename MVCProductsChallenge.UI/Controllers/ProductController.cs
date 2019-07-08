using MVCProductsChallenge.Model.Entities;
using MVCProductsChallenge.Services;
using MVCProductsChallenge.UI.Helpers;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace MVCProductsChallenge.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController()
        {
            _productService = new ProductService();
        }

        public ActionResult Index()
        {
            ViewBag.Products = _productService
                .List()
                .Include(x => x.ProductType)
                .ToList();

            return View();
        }

        [HttpPost]
        public ActionResult GetProducts(string identifier, string description)
        {
            if (string.IsNullOrWhiteSpace(identifier))
                identifier = null;

            if (string.IsNullOrWhiteSpace(description))
                description = null;

            var products = _productService
                .List()
                .Include(x => x.ProductType)
                .Where(x => (identifier == null || x.Identifier == identifier) && (description == null || x.Description.ToLower().Contains(description.ToLower())))
                .ToList();

            return PartialView("_ProductsTable", products);
        }

        public ActionResult CreateProduct() => View(new Product());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitCreateProduct([Bind(Include = "Description,Price,ProductTypeId")] Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productService.Create(product);
                    TempData["Message"] = MessageHelpers.GetSuccessMessage($"Product '{product.Description}' was added successfully");
                    return RedirectToAction("Index");
                }

                return View("CreateProduct", product);
            }
            catch (Exception ex)
            {
                TempData["Message"] = MessageHelpers.GetExceptionMessage(ex);
                return View("CreateProduct", product);
            }
        }

        public ActionResult EditProduct(int productId)
        {
            var selectedProduct = _productService.Get(productId);
            return View("EditProduct", selectedProduct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitEditProduct([Bind(Include = "Id,Identifier,CreationDate,Description,Price,ProductTypeId,ProductStatus")] Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var oldProduct = _productService.Get(product.Id);
                    _productService.Update(oldProduct, product);
                    TempData["Message"] = MessageHelpers.GetSuccessMessage($"Product '{product.Description}' was edited successfully");
                    return RedirectToAction("Index");
                }

                return View("EditProduct", product);
            }
            catch (Exception ex)
            {
                TempData["Message"] = MessageHelpers.GetExceptionMessage(ex);
                return View("EditProduct", product);
            }
        }
    }
}
using MVCProductsChallenge.Model.Entities;
using MVCProductsChallenge.Services;
using MVCProductsChallenge.UI.Helpers;
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

        public ActionResult CreateProductType()
        {
            ViewBag.Title = "Create product type";

            return View(new ProductType());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitCreateProductType([Bind(Include = "Name")] ProductType productType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productTypeService.Create(productType);
                    TempData["Message"] = MessageHelpers.GetSuccessMessage("Product type added successfully");
                    return RedirectToAction("Index");
                }

                return View("CreateProductType", productType);
            }
            catch (Exception ex)
            {
                TempData["Message"] = MessageHelpers.GetExceptionMessage(ex);
                return View("CreateProductType", productType);
            }
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
            try
            {
                if (ModelState.IsValid)
                {
                    var oldProductType = _productTypeService.Get(productType.Id);
                    _productTypeService.Update(oldProductType, productType);
                    TempData["Message"] = MessageHelpers.GetSuccessMessage("Product type edited successfully");
                    return RedirectToAction("Index");
                }

                return View("EditProductType", productType);
            }
            catch (Exception ex)
            {
                TempData["Message"] = MessageHelpers.GetExceptionMessage(ex);
                return View("EditProductType", productType);
            }
        }
    }
}
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

            return View();
        }
    }
}
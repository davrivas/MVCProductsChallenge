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

            var viewModel = new IndexViewModel
            {
                Title = "Products",
                Products = products
            };

            return View(viewModel);
        }
    }
}
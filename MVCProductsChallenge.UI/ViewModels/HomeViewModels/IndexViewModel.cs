using MVCProductsChallenge.Model.Entities;
using System.Collections.Generic;

namespace MVCProductsChallenge.UI.ViewModels.HomeViewModels
{
    public sealed class IndexViewModel : BaseViewModel
    {
        public Product NewProduct { get; set; }
        public IList<Product> Products { get; set; }
        public IList<ProductType> ProductTypes { get; set; }
    }
}
using MVCProductsChallenge.Model.Entities;
using System.Collections.Generic;

namespace MVCProductsChallenge.UI.ViewModels.HomeViewModels
{
    public sealed class IndexViewModel : BaseViewModel
    {
        public IList<Product> Products { get; set; }
    }
}
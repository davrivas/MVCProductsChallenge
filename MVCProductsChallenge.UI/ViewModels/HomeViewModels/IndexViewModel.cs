using MVCProductsChallenge.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProductsChallenge.UI.ViewModels.HomeViewModels
{
    public sealed class IndexViewModel : BaseViewModel
    {
        public IList<Product> Products { get; set; }
    }
}
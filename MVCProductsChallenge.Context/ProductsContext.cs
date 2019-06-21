using MVCProductsChallenge.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCProductsChallenge.Context
{
    public class ProductsContext : DbContext
    {
        public ProductsContext() : base(string.Empty)
        {
        }

        public IDbSet<Product> Products { get; set; }
        public IDbSet<ProductType> ProductTypes { get; set; }
    }
}

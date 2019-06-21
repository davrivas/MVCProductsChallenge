using MVCProductsChallenge.Model.Entities;
using System.Configuration;
using System.Data.Entity;

namespace MVCProductsChallenge.Context
{
    public class ProductsContext : DbContext
    {
        private static readonly string _connectionString = ConfigurationManager.ConnectionStrings["ProductConnection"].ToString();

        public ProductsContext() : base(_connectionString)
        {
        }

        public IDbSet<Product> Products { get; set; }
        public IDbSet<ProductType> ProductTypes { get; set; }
    }
}

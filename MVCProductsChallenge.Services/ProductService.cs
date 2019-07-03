using MVCProductsChallenge.Model.Entities;
using MVCProductsChallenge.Model.Enums;
using MVCProductsChallenge.Services.Generators;
using System;
using System.Linq;

namespace MVCProductsChallenge.Services
{
    public interface IProductService : IBaseService<Product>
    {
        bool ProductExists(string identifier);
    }

    public sealed class ProductService : BaseService<Product>, IProductService
    {
        public override void Create(Product entity)
        {
            do
            {
                entity.Identifier = CodeGenerator.GenerateCode();
            } while (ProductExists(entity.Identifier));

            entity.CreationDate = DateTime.Now;
            entity.ProductStatus = ProductStatus.Active;
            base.Create(entity);
        }

        public bool ProductExists(string identifier)
        {
            var product = List().Where(x => x.Identifier == identifier).FirstOrDefault();
            bool productExists = product != null;
            return productExists;
        }
    }
}

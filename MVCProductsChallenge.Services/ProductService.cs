using MVCProductsChallenge.Model.Entities;
using MVCProductsChallenge.Model.Enum;
using System;

namespace MVCProductsChallenge.Services
{
    public interface IProductService : IBaseService<Product>
    {
    }

    public sealed class ProductService : BaseService<Product>, IProductService
    {
        public override void Create(Product entity)
        {
            entity.CreationDate = DateTime.Now;
            entity.ProductStatus = ProductStatus.Active;
            base.Create(entity);
        }
    }
}

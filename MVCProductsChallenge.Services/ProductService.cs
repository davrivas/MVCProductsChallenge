using MVCProductsChallenge.Model.Entities;
using MVCProductsChallenge.Model.Enum;
using MVCProductsChallenge.Services.Generators;
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
            entity.Identifier = CodeGenerator.GenerateCode();
            entity.CreationDate = DateTime.Now;
            entity.ProductStatus = ProductStatus.Active;
            base.Create(entity);
        }

        public override void Update(Product oldEntity, Product newEntity)
        {
            newEntity.Id = oldEntity.Id;
            newEntity.Identifier = oldEntity.Identifier;
            newEntity.CreationDate = oldEntity.CreationDate;
            base.Update(oldEntity, newEntity);
        }
    }
}

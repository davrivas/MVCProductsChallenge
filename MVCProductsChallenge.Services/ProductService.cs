using MVCProductsChallenge.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            base.Create(entity);
        }
    }
}

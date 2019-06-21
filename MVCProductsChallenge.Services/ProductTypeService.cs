using MVCProductsChallenge.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCProductsChallenge.Services
{
    public interface IProductTypeService : IBaseService<ProductType>
    {
    }

    public sealed class ProductTypeService : BaseService<ProductType>, IProductTypeService
    {
    }
}

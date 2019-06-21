using MVCProductsChallenge.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCProductsChallenge.Services
{
    public interface IBaseService<T>
    {
    }

    public class BaseService
    {
        private readonly ProductsContext dbContext;

        public BaseService()
        {
            dbContext = new ProductsContext();
        }
    }
}

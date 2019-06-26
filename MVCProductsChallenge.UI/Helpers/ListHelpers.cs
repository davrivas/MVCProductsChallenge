using MVCProductsChallenge.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVCProductsChallenge.UI.Helpers
{
    public static class ListHelpers
    {
        public static IList<SelectListItem> GetProductTypes()
        {
            var productTypes = new ProductTypeService()
                .List()
                .OrderBy(x => x.ProductTypeName)
                .Select(x => new SelectListItem
                {
                    Text = x.ProductTypeName,
                    Value = x.Id.ToString()
                })
                .ToList();
            return productTypes;
        }
    }
}
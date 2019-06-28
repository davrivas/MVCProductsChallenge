using MVCProductsChallenge.Model.Enums;
using MVCProductsChallenge.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVCProductsChallenge.UI.Helpers
{
    public static class ListHelpers
    {
        public static IList<SelectListItem> GetProductTypes(int productTypeId = 0)
        {
            var productTypes = new ProductTypeService()
                .List()
                .OrderBy(x => x.ProductTypeName)
                .Select(x => new SelectListItem
                {
                    Text = x.ProductTypeName,
                    Value = x.Id.ToString(),
                    Selected = productTypeId == x.Id
                })
                .ToList();
            return productTypes;
        }

        public static IList<SelectListItem> GetProductStatuses(int productStatus)
        {
            var values = Enum.GetValues(typeof(ProductStatus));

            var productStatuses = new List<SelectListItem>();

            for (int i = 0; i < values.Length; i++)
            {
                var value = values.GetValue(i);
                var item = new SelectListItem
                {
                    Text = value.ToString(),
                    Value = i.ToString(),
                    Selected = productStatus == i
                };
                productStatuses.Add(item);
            }

            return productStatuses;
        }
    }
}
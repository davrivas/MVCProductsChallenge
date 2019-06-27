using MVCProductsChallenge.Model.Entities;
using MVCProductsChallenge.Model.Enum;
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
            var productTypeService = new ProductTypeService();

            var productTypes = productTypeService
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

        public static IList<SelectListItem> GetProductStatuses(ProductStatus productStatus)
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
                    Selected = productStatus.ToString() == value.ToString()
                };
                productStatuses.Add(item);
            }

            return productStatuses;
        }
    }
}
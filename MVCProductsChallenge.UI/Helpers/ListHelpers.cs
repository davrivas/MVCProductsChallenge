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
            var productTypes = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Select product type",
                    Value = "0",
                    Selected = productTypeId == 0
                }
            };

            var productTypesRange = new ProductTypeService()
                .List()
                .OrderBy(x => x.Name)
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString(),
                    Selected = productTypeId == x.Id
                })
                .ToList();

            productTypes.AddRange(productTypesRange);

            return productTypes;
        }

        public static IList<SelectListItem> GetProductStatuses(ProductStatus productStatus)
        {
            var active = new SelectListItem
            {
                Text = ProductStatus.Active.ToString(),
                Value = Convert.ToInt32(ProductStatus.Active).ToString(),
                Selected = productStatus.ToString() == ProductStatus.Active.ToString()
            };

            var inactive = new SelectListItem
            {
                Text = ProductStatus.Inactive.ToString(),
                Value = Convert.ToInt32(ProductStatus.Inactive).ToString(),
                Selected = productStatus.ToString() == ProductStatus.Inactive.ToString()
            };

            var productStatuses = new List<SelectListItem>();

            if (productStatus.ToString() == ProductStatus.Inactive.ToString())
            {
                productStatuses.Add(inactive);
                productStatuses.Add(active);
            }
            else
            {
                productStatuses.Add(active);
                productStatuses.Add(inactive);
            }

            return productStatuses;
        }
    }
}
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

            }
            else
            {

            }

            return productStatuses;
        }
    }
}
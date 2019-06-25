using MVCProductsChallenge.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MVCProductsChallenge.UI.Extensions
{
    public static class HtmlExtensions
    {
        public static string Drop(this HtmlHelper helper, IList<SelectListItem> select)
        {
            var sb = new StringBuilder();
            sb.Append("<select>");
            foreach (var item in select)
            {
                sb.AppendFormat("<option value='{0}' {2}>{1}</option>", item.Value, item.Text, (item.Selected ? "selected" : ""));
            }
            sb.Append("</select>");
            return sb.ToString();
        }

        public static string GetProductTypes(this HtmlHelper a, IEnumerable<ProductType> productTypes, ProductType selectedProductType)
        {
            var items = new List<SelectListItem>();

            foreach (var productType in productTypes)
            {
                var item = new SelectListItem { Text = productType.ProductTypeName, Value = productType.Id.ToString() };

                if (selectedProductType != null)
                {
                    if (selectedProductType.Equals(productType))
                        item.Selected = true;
                }

                items.Add(item);
            }

            if (selectedProductType == null)
            {
                if (items.Count > 0)
                    items[0].Selected = true;
            }

            return Drop(a, items);
        }
    }
}
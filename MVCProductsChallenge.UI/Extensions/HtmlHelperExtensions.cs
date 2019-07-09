using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;

namespace MVCProductsChallenge.UI.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString CustomDropdownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IList<SelectListItem> list, object htmlAttributes = null)
        {
            TProperty value;

            try
            {
                value = htmlHelper != null &&
                        htmlHelper.ViewData != null &&
                        htmlHelper.ViewData.Model == null ? default : expression.Compile().Invoke(htmlHelper.ViewData.Model);
            }
            catch (Exception)
            {
                value = default;
            }

            var optionSelected = string.Empty;

            if (value != null)
                optionSelected = value.ToString().TrimStart().TrimEnd();

            var items = list.ToList();
            items.ForEach(i => i.Selected = i.Value.TrimStart().TrimEnd() == optionSelected);

            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            string name = ExpressionHelper.GetExpressionText(expression);

            return CustomDropdownList(htmlHelper, name, items, htmlAttributes, metadata);
        }

        private static MvcHtmlString CustomDropdownList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> list, object htmlAttributes = null, ModelMetadata metadata = null)
        {
            string fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);

            if (string.IsNullOrEmpty(fullName))
            {
                throw new ArgumentException("name");
            }

            var dropdown = new TagBuilder("select");
            dropdown.Attributes.Add("name", fullName);
            dropdown.Attributes.Add("id", fullName);
            if (htmlAttributes != null) dropdown.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            if (metadata != null) dropdown.MergeAttributes(htmlHelper.GetUnobtrusiveValidationAttributes(name, metadata));

            var options = new StringBuilder();

            foreach (var item in list)
            {
                options = options.Append(
                    "<option" +
                    (string.IsNullOrWhiteSpace(item.Value) ? " value=''" : " value='" + item.Value + "'") +
                    (item.Selected ? " selected='selected'" : string.Empty) +
                    ">" + item.Text + "</option>");
            }

            dropdown.InnerHtml = options.ToString();

            return MvcHtmlString.Create(dropdown.ToString(TagRenderMode.Normal));
        }
    }
}
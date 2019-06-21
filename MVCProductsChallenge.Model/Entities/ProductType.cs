using System.Collections.Generic;

namespace MVCProductsChallenge.Model.Entities
{
    public sealed class ProductType : BaseEntity
    {
        public string ProductTypeName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
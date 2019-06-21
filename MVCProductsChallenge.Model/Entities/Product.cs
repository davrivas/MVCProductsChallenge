using MVCProductsChallenge.Model.Enum;
using System;

namespace MVCProductsChallenge.Model.Entities
{
    public sealed class Product : BaseEntity
    {
        public string Identifier { get; set; }
        public string Description { get; set; }
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
        public decimal Price { get; set; }
        public DateTime CreationDate { get; set; }
        public ProductStatus ProductStatus { get; set; }
    }
}

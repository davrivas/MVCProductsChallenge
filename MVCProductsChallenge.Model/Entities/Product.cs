using MVCProductsChallenge.Model.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace MVCProductsChallenge.Model.Entities
{
    public sealed class Product : BaseEntity
    {
        public string Identifier { get; set; }
        [Required]
        public string Description { get; set; }
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }
        public DateTime CreationDate { get; set; }
        [Required]
        public ProductStatus ProductStatus { get; set; }
    }
}

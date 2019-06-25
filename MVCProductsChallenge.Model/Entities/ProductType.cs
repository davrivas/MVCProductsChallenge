using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCProductsChallenge.Model.Entities
{
    public sealed class ProductType : BaseEntity
    {
        [Required]
        public string ProductTypeName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
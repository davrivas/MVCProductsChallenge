using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCProductsChallenge.Model.Entities
{
    public sealed class ProductType : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
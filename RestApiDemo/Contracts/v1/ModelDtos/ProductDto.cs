using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApiDemo.Contracts.v1.ModelDtos
{
    /// <summary>
    /// API contract Model of product accessible via api
    /// </summary>
    public class ProductDto
    {
        /// <summary>
        /// Id (PK)
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Name of product
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Url to the product image
        /// </summary>
        [Required]
        public string ImgUri { get; set; }

        /// <summary>
        /// Price of the product
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18,4)")] //https://mattferderer.com/entity-framework-no-type-was-specified-for-the-decimal-column
        public decimal Price { get; set; }

        /// <summary>
        /// Description of the product
        /// </summary>
        public string Description { get; set; }
    }
}

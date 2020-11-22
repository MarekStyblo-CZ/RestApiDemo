using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiDemo.Models.DbSets
{
    public class Product
    {
        [Key, Column(Order = 0), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ImgUri { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")] //https://mattferderer.com/entity-framework-no-type-was-specified-for-the-decimal-column
        public decimal Price { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            return $"Id: {this.Id}, Name: {this.Name}, ImgUri: {this.ImgUri}, Price: {this.Price}, Description: {this.Description}";
        }
    }
}

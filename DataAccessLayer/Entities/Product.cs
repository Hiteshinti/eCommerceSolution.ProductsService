using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
     public class Product
     {
        [Key]
        public Guid ProductId { get; set; }

        [Required(ErrorMessage ="filed is is required")]
        public string? ProductName { get; set; }
        [Required(ErrorMessage ="field is required")]
        public string? Category {  get; set; }
        [Required(ErrorMessage = "field is required")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Only numeric values with optional decimals are allowed.")]
        public decimal? UnitPrice { get; set; }
        [Required(ErrorMessage = "field is required")]
        [RegularExpression(@"^\d+(\.\d+)?$", ErrorMessage = "Only numeric values with optional decimals are allowed.")]
        public int? QuantityInStock { get; set; }    
     }
}

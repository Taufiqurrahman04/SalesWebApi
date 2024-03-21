using System.ComponentModel.DataAnnotations;

namespace SalesOrderWebApi.Models.DataModifyViewModels
{
    public class base_products 
    {
        [Required(ErrorMessage = "This field is required")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "This field must not be empty")]
        public string code { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "This field must not be empty")]
        public string description { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "This field must not be empty")]
        public string type { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "This field must not be empty")]
        public string brand { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "This field must not be empty")]
        public string uom { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public decimal cogs { get; set; }
    }
}

using SalesOrderWebApi.Utilities.Extension.Globalization;
using System.ComponentModel.DataAnnotations;

namespace SalesOrderWebApi.Models.DataModifyViewModels
{
    public class base_order
    {
        [Required(ErrorMessage = "This field is required")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "This field must not be empty")]
        public string customer_id { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "This field must not be empty")]
        public string store_id { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public DateTime order_date { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [MinLength(1, ErrorMessage = "Value must greather than 0")]
        public decimal total_amount { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "This field must not be empty")]
        public string order_type { get; set; }
    }
}

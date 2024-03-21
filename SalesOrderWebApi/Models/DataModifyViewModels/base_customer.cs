using System.ComponentModel.DataAnnotations;

namespace SalesOrderWebApi.Models.DataModifyViewModels
{
    public class base_customer
    {
        [Required(ErrorMessage = "This field is required")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "This field must not be empty")]
        public string customer_no { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "This field must not be empty")]
        public string customer_name { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "This field must not be empty")]
        public string address { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "This field must not be empty")]
        public string phone { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "This field must not be empty")]
        public string customer_type { get; set; }
    }
}

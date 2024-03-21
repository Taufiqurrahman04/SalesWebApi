using System.ComponentModel.DataAnnotations;

namespace SalesOrderWebApi.Models.DataModifyViewModels
{
    public class base_order_item
    {

        [Required(ErrorMessage = "This field is required")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "This field must not be empty")]
        public string order_id { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "This field must not be empty")]
        public string product_sparepart_id { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [MinLength(1, ErrorMessage = "Value must greather than 0")]
        public int quantity { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [MinLength(1, ErrorMessage = "Value must greather than 0")]
        public decimal unit_price { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [MinLength(1, ErrorMessage = "Value must greather than 0")]
        public decimal total_price { get; set; }
    }
}

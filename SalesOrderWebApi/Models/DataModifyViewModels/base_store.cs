using System.ComponentModel.DataAnnotations;

namespace SalesOrderWebApi.Models.DataModifyViewModels
{
    public class base_store
    {
        [Required(ErrorMessage = "This field is required")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "This field must not be empty")]
        public string code { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "This field must not be empty")]
        public string description { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "This field must not be empty")]
        public string address { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "This field must not be empty")]
        public string phone { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "This field must not be empty")]
        public string marketing_area_id { get; set; }
    }
}

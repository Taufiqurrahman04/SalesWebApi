using System.ComponentModel.DataAnnotations;

namespace SalesOrderWebApi.Models.DataModifyViewModels
{
    public class base_marketing
    {
        [Required(ErrorMessage = "This field is required")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "This field must not be empty")]
        public string code { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "This field must not be empty")]
        public string description { get; set; }
    }
}

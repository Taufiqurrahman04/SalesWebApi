using SalesOrderWebApi.Entity;
using SalesOrderWebApi.Models.DataModifyViewModels;
using System.ComponentModel.DataAnnotations;

namespace SalesOrderWebApi.Models.DataViewModels
{
    public class marketing_area : base_marketing
    {
        public string id { get; set; }
        public IEnumerable<store> stores { get; set; }
    }
}

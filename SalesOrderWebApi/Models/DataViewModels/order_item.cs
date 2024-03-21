using SalesOrderWebApi.Entity;
using SalesOrderWebApi.Models.DataModifyViewModels;
using System.ComponentModel.DataAnnotations;

namespace SalesOrderWebApi.Models.DataViewModels
{
    public class order_item : base_order_item
    {
        public string id { get; set; }
        public order order { get; set; }
        public product_sparepart product_sparepart { get; set; }
    }
}

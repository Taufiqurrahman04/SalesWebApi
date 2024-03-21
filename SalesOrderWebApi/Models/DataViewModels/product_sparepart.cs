using SalesOrderWebApi.Models.DataModifyViewModels;
using System.ComponentModel.DataAnnotations;

namespace SalesOrderWebApi.Models.DataViewModels
{
    public class product_sparepart : base_products
    {
        public string id { get; set; }

        public IEnumerable<order_item> order_Items { get; set; }
    }
}

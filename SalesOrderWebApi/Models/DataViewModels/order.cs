using SalesOrderWebApi.Entity;
using SalesOrderWebApi.Models.DataModifyViewModels;
using System.ComponentModel.DataAnnotations;

namespace SalesOrderWebApi.Models.DataViewModels
{
    public class order : base_order
    {
        public string id { get; set; }
        public customer customer { get; set; }
        public store store { get; set; }
        public IEnumerable<order_item> order_Items { get; set; }
    }
}

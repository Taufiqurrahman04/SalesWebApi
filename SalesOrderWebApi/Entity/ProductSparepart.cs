using System.ComponentModel.DataAnnotations;

namespace SalesOrderWebApi.Entity
{
    public class ProductSparepart
    {
        [Key]
        public string Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }
        public string UOM { get; set; }
        public decimal COGS { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}

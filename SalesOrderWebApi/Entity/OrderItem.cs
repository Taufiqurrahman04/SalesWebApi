using System.ComponentModel.DataAnnotations;

namespace SalesOrderWebApi.Entity
{
    public class OrderItem
    {
        [Key]
        public string Id { get; set; }
        public virtual Order Order { get; set; }
        public string OrderId { get; set; }
        public virtual ProductSparepart ProductSparepart { get; set; }
        public string ProductSparepartId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

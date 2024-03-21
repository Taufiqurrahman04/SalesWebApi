using System.ComponentModel.DataAnnotations;

namespace SalesOrderWebApi.Entity
{
    public class Order
    {
        [Key]
        public string Id { get; set; }
        public virtual Customer Customer { get; set; }
        public string CustomerId { get; set; }
        public virtual Store Store { get; set; }
        public string StoreId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string OrderType { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}

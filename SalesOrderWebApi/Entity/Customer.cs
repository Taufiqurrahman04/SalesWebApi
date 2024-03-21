using System.ComponentModel.DataAnnotations;

namespace SalesOrderWebApi.Entity
{
    public class Customer
    {
        [Key]
        public string Id { get; set; }
        public string CustomerNo { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string CustomerType { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace SalesOrderWebApi.Entity
{
    public class Store
    {
        [Key]
        public string Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public virtual MarketingArea MarketingArea { get; set; }
        public string MarketingAreaId { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}

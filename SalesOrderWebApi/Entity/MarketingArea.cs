using System.ComponentModel.DataAnnotations;

namespace SalesOrderWebApi.Entity
{
    public class MarketingArea
    {
        [Key]
        public string Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public ICollection<Store> Stores { get; set; }
    }
}

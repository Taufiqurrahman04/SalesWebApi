using SalesOrderWebApi.Models.DataModifyViewModels;
using System.ComponentModel.DataAnnotations;

namespace SalesOrderWebApi.Models.DataViewModels
{
    public class customer : base_customer
    {
        public string id { get; set; }
        
        public IEnumerable<order> orders { get; set; }
    }
}

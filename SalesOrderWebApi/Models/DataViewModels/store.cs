using SalesOrderWebApi.Entity;
using SalesOrderWebApi.Models.DataModifyViewModels;
using System.ComponentModel.DataAnnotations;

namespace SalesOrderWebApi.Models.DataViewModels
{
    public class store : base_store
    {
        public string id { get; set; }
        
        public marketing_area marketing_area { get; set; }

        public IEnumerable<order> orders { get; set; }
    }
}

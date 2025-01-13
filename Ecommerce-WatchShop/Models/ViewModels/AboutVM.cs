using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce_WatchShop.Models.ViewModels
{
    public class AboutVM
    {
        public About? About { get; set; }
        public List<Policy>? Policies { get; set; }
    }
}

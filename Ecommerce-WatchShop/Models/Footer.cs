using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_WatchShop.Models
{
    public partial class Footer
    {
        [Key]
        public int Id { get; set; }
        public string? WebsiteName {  get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string? Address { get; set; }
        public string? Description { get; set; }
        public string? Logo { get; set; }
    }
}

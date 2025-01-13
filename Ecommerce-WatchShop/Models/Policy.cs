using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce_WatchShop.Models;
public partial class Policy 
{
    [Key]
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
}
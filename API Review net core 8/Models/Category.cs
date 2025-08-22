using System.ComponentModel.DataAnnotations;

namespace API_Review_net_core_8.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string? Name { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace PortsManagement.Models
{
    public class Port
    {
        [Key]
        [Required]
        [MinLength(5)]
        public string PortCode { get; set; }

        [Required]
        [MinLength(5)]
        public string Name { get; set; }

        [Required]
        public DateTime AddedDate { get; set; } = DateTime.UtcNow;

        public DateTime LastEditedDate { get; set; } = DateTime.UtcNow;

        public ICollection<Terminal> Terminals { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PortsManagement.Models
{
    public class Terminal
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [ForeignKey("Port")]
        public string PortCode { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public DateTime AddedDate { get; set; } = DateTime.UtcNow;

        public DateTime LastEditedDate { get; set; } = DateTime.UtcNow;

        public Port Port { get; set; }
    }
}


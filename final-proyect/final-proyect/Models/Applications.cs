using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace final_proyect_backend.Models
{
    public class Applications
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Users")]
        public int UserId { get; set; }
        [Required]
        [ForeignKey("Offers")]
        public int OfferId { get; set; }

        public int AplicationState { get; set; }

        public Users Users { get; set; }

        public Offers Offers { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace final_proyect_backend.Models
{
    public class Applications
    {
        [Key]
        public int Id { get; set; }
        [Required]
        
        public int UserId { get; set; }
        [Required]
        
        public int OfferId { get; set; }

        public int AplicationState { get; set; }


    }
}

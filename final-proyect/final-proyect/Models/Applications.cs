using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace final_proyect_backend.Models
{
    public class Applications
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApplicationID { get; set; }
       

        // relacion a oferta

        [Required]
        public int OfferId { get; set; }

        [ForeignKey("OfferId")]


        // relacion a user

        [Required]
       
        public int UserId { get; set; }

        [ForeignKey("UserId")]

        public int AplicationState { get; set; }



    }
}









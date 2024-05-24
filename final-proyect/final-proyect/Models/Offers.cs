using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace final_proyect_backend.Models
{
    public class Offers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OfferId { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public string Tittle { get; set; }
        public string About { get; set; }
        public DateTime InitDate { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime FinishDate { get; set; }
        public string From { get; set; }
        public string Location { get; set; }
        public string Sector { get; set; }
        public string SkillsRequired { get; set; }
        public bool InmediteIncorporation { get; set; }
        public bool Intern { get; set; }
        public int CareerMinimumAge { get; set; }
        public int CareersInterested {  get; set; }
        public int InternTime {  get; set; }
        public bool IsPaid { get; set; }
        public bool OfferState { get; set; }



       









    }
}

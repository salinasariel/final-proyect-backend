using System.ComponentModel.DataAnnotations;

namespace final_proyect_backend.Models
{
    public class Offers
    {
        [Key]
        public int OfferId { get; set; }

        public int EnterpriseId { get; set; }
        public string Tittle { get; set; }
        public string About { get; set; }
        public DateTime InitDate { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime FinishDate { get; set; }
        public String From { get; set; }
        public String Location { get; set; }
        public String Sector { get; set; }
        public String SkillsRequired { get; set; }

        public bool InmediteIncorporation { get; set; }



        public bool Intern { get; set; }
        public int CareerMinimumAge { get; set; }
        public int CareersInterested {  get; set; }
        public int InternTime {  get; set; }
        public bool IsPaid { get; set; }


        public bool OfferState { get; set; }




    }
}

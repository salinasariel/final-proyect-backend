using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace final_proyect_backend.Models
{
    public class Students : Users
    {
        public int FileNumber { get; set; }
        public int Dni { get; set; }
        public long Cuil { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate {  get; set; }
        public string Sex { get; set; }
        public string CivilStatus { get; set; }
        public string Tittle {  get; set; }
        public string Education {  get; set; }
        public string Experience { get; set; }
        public int EnglishLevel {get; set; }










    }
}

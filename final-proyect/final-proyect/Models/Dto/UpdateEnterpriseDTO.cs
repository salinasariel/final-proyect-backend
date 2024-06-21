using System.ComponentModel.DataAnnotations;

namespace final_proyect.Models.Dto
{
    public class UpdateEnterpriseDTO
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string ProfilePhoto { get; set; }
        public string About { get; set; } 

        public string City { get; set; } 
        public string WebPage { get; set; } 

        public string LegalAbout { get; set; } 
        public string CompanyAbout { get; set; } 
        public string ContactName { get; set; } 
        [EmailAddress]
        public string ContactEmail { get; set; } 
        public string ContactPhone { get; set; }  
        public int? EnterpriseType { get; set; }  
        public int? EmployeesQuantity { get; set; } 
        public long? Cuit { get; set; } 

    }
}







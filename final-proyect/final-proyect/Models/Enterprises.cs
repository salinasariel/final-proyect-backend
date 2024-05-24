using System.Text.Json.Serialization;

namespace final_proyect_backend.Models
{
    public class Enterprises : Users
    {
        public string City { get; set; }
        public string WebPage {  get; set; }
        public string AboutCompany { get; set; }
        public string LegalAbout {  get; set; }
        public string CompanyAbout { get; set; }
        public string ContactName {get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public int EnterpriseType {  get; set; }
        public int EmployeesQuantity { get; set; }
        public long Cuit { get; set; }

  




    }
}

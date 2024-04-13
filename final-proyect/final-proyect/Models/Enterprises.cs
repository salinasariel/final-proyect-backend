namespace final_proyect_backend.Models
{
    public class Enterprises : Users
    {
        public String City { get; set; }
        public String WebPage {  get; set; }
        public String AboutCompany { get; set; }
        public String LegalAbout {  get; set; }


        public String CompanyAbout { get; set; }
        public String ContactName {get; set; }
        public String ContactEmail { get; set; }
        public String ContactPhone { get; set; }

        public int EnterpriseType {  get; set; }
        public int EmployeesQuantity { get; set; }



    }
}

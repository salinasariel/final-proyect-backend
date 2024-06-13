namespace final_proyect.Models.Dto
{
    public class UpdateStudentDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }

        public int? FileNumber { get; set; }
        public int? Dni { get; set; }
        public long? Cuil { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Sex { get; set; }
        public string CivilStatus { get; set; }
        public string Tittle { get; set; }
        public int? CareerAge { get; set; }
        public int? EnglishLevel { get; set; }
        public string HighSchoolFile { get; set; }
        public string CoursesFile { get; set; }

    }
}

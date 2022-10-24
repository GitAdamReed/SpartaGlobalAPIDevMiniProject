namespace APIMiniProject.Models.DTOs
{
    public class BirthdayDTO
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime? BirthDate { get; set; }
        public DateTime? UpcomingBirthdate { get; set; }
    }
}

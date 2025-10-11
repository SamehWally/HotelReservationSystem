namespace Presentation.ViewModels.Staff
{
    public sealed class StaffVM
    {
        public int Id { get; set; }

        public string? Department { get; set; }
        public DateTime? HireDate { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
    }
}

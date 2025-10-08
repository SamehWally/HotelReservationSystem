namespace Presentation.ViewModels.Staff
{
    public record AddStaffVM(string Username, string Email, string Password, int RoleId);
    public record StaffVM(int Id, string Username, string Email);
}

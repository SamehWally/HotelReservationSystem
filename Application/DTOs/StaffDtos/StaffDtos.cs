namespace Application.DTOs.StaffDtos
{
    public record AddStaffDto(string Username, string Email, string Password, int RoleId);
    public record StaffDto(int Id, string Username, string Email);
}

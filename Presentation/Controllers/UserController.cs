using Application.DTOs.User;
using Application.Services;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels.Response;
using Presentation.ViewModels.User;

namespace Presentation.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public ResponseViewModel<IEnumerable<UserInfoResponseViewModel>> GetAllUsers()
        {
            var result = _userService.GetAllUsers();

            if (!result.IsSuccess || result.Data == null)
                return  new ErrorResponseViewModel<IEnumerable<UserInfoResponseViewModel>>(ErrorCode.NotFound, "No users found.");

            // Mapping from DTO -> ResponseViewModel
            var userList = result.Data.Select(u => new UserInfoResponseViewModel
            {
                Id = u.Id,
                FullName = u.FullName,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber
            }).ToList();

            return new SuccessResponseViewModel<IEnumerable<UserInfoResponseViewModel>>(userList, "Users retrieved successfully.");
        }

        [HttpPost]
        public async Task<ResponseViewModel<bool>> AddUser([FromBody] AddUserRequestViewModel model)
        {
            if (!ModelState.IsValid)
                return new ErrorResponseViewModel<bool>(ErrorCode.InvalidInput, "Invalid input data.");

            // Mapping from ViewModel -> DTO
            var userDto = new AddUserDto
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Username = model.Username,
                PhoneNumber = model.PhoneNumber,
                Password = model.Password,
                Address = model.Address,
                City = model.City,
                Country = model.Country
            };

            var success = await _userService.AddUserAsync(userDto);

            if (!success)
                return new ErrorResponseViewModel<bool>(ErrorCode.Duplicate, "User already exists with this email.");

            return new SuccessResponseViewModel<bool>(true, "User added successfully.");
        }

        [HttpDelete]
        public async Task<ResponseViewModel<bool>> DeleteUser(int userId)
        {
            var success = await _userService.DeleteUserAsync(userId);
            if (!success)
                return new ErrorResponseViewModel<bool>(ErrorCode.NotFound, "User not found.");
            return new SuccessResponseViewModel<bool>(true, "User deleted successfully.");
        }
    }
}

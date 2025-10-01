using Application.DTOs.Login;
using Application.DTOs.StaffDtos;
using AutoMapper;
using Domain.Models.Auth.Models;
using Presentation.ViewModels.JWT;
using Presentation.ViewModels.Login;
using Presentation.ViewModels.Staff;

namespace Presentation.ViewModels.Mapping
{
    public class StaffProfileViewModel : Profile
    {
        public StaffProfileViewModel()
        {
            CreateMap<AddStaffVM, AddStaffDto>();

            CreateMap<StaffDto, StaffVM>();
        }
    }
}

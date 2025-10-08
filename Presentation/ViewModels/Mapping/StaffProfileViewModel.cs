using Application.DTOs.StaffDtos;
using AutoMapper;
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

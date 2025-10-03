using Application.DTOs.StaffDtos;
using AutoMapper;
using Domain.Models.Users;

namespace Application.DTOs.Mapping
{
    public class StaffProfileDto : Profile
    {
        public StaffProfileDto()
        {
            CreateMap<Staff, StaffDto>();

            CreateMap<AddStaffDto, Staff>()
                .ForMember(d => d.PasswordHash, o => o.Ignore()) 
                .ForMember(d => d.Id, o => o.Ignore()); 
        }
    }
}

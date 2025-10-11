using Application.DTOs.StaffDtos;
using AutoMapper;
using Domain.Models.Users;

namespace Application.DTOs.Mapping
{
    public class StaffProfileDto : Profile
    {
        public StaffProfileDto()
        {
            CreateMap<Staff, StaffDto>()
            .ForMember(d => d.UserId, o => o.MapFrom(s => s.User.Id))
            .ForMember(d => d.FirstName, o => o.MapFrom(s => s.User.FirstName))
            .ForMember(d => d.LastName, o => o.MapFrom(s => s.User.LastName))
            .ForMember(d => d.Email, o => o.MapFrom(s => s.User.Email))
            .ForMember(d => d.UserName, o => o.MapFrom(s => s.User.Username))
            .ForMember(d => d.Phone, o => o.MapFrom(s => s.User.PhoneNumber))
            .ForMember(d => d.Address, o => o.MapFrom(s => s.User.Address))
            .ForMember(d => d.City, o => o.MapFrom(s => s.User.City))
            .ForMember(d => d.Country, o => o.MapFrom(s => s.User.Country));

        }
    }
}

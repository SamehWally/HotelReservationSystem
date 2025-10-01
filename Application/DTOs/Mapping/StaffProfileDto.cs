using Application.DTOs.StaffDtos;
using AutoMapper;
using Domain.Models.Users;
using Domain.Repositories.StaffRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

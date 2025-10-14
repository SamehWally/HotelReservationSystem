using Application.DTOs.Role;
using AutoMapper;
using Presentation.ViewModels.Role;
using Presentation.ViewModels.Room;

namespace Presentation.ViewModels.Mapping
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<AddRoleVM, AddRoleDto>();

            CreateMap<AddRoleDto, Domain.Models.AccessControl.Role>();
        }
    }
}

using Application.DTOs.Login;
using AutoMapper;
using Domain.Models.Auth.Models;
using Presentation.ViewModels.JWT;
using Presentation.ViewModels.Login;

namespace Presentation.ViewModels.Mapping
{
    public class TokenProfileViewModel : Profile
    {
        public TokenProfileViewModel()
        {
            CreateMap<TokenResponseDto, TokenResponseVM>()
            .ForMember(d => d.token_type, o => o.MapFrom(_ => "Bearer"))
            .ForMember(d => d.access_token, o => o.MapFrom(s => s.AccessToken))
            .ForMember(d => d.expires_in, o => o.MapFrom(s =>
                (int)Math.Max(0, (s.ExpiresAt - DateTime.UtcNow).TotalSeconds)));

            CreateMap<LoginRequestVM, LoginRequestDto>().ReverseMap();
        }
    }
}

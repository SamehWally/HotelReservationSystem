using Application.DTOs.Report;

using Domain.Models.Reservation;

namespace Application.Mappings
{
    public class ReportProfileDto : AutoMapper.Profile
    {
        public ReportProfileDto()
        {
            // Booking report: يحسب عدد الحجوزات لكل شهر
            CreateMap<IGrouping<int, Reservation>, BookingReportDto>()
                .ForMember(d => d.Month, o => o.MapFrom(s => s.Key))
                .ForMember(d => d.TotalReservations, o => o.MapFrom(s => s.Count()));

            // Revenue report: يحسب مجموع الإيرادات لكل شهر
            //CreateMap<IGrouping<int, Reservation>, RevenueReportDto>()
            //    .ForMember(d => d.Month, o => o.MapFrom(s => s.Key))
            //    .ForMember(d => d.TotalRevenue, o => o.MapFrom(s => s.Sum(r => r.Amount)));

            // Popular rooms: نحسب عدد الحجوزات لكل غرفة، RoomType يتم تجاهله
            CreateMap<IGrouping<int, Reservation>, PopularRoomDto>()
                .ForMember(d => d.BookedCount, o => o.MapFrom(s => s.Count()))
                .ForMember(d => d.RoomType, o => o.Ignore());

            // Customer analytics: نحسب عدد الحجوزات وآخر شهر، CustomerName يتم تجاهله
            CreateMap<IGrouping<int, Reservation>, CustomerBookingAnalyticsDto>()
         .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Key))
         .ForMember(dest => dest.TotalReservations, opt => opt.MapFrom(src => src.Count()))
         .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src =>
             (src.First().Customer != null && src.First().Customer.User != null)
                 ? $"{src.First().Customer.User.FirstName} {src.First().Customer.User.LastName}".Trim()
                 : "Unknown"
         ));
        }
    }
}
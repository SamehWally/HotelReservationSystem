using Application.DTOs.Report;

using Domain.Models.Reservation;

namespace Application.Mappings
{
    public class ReportProfile : AutoMapper.Profile
    {
        public ReportProfile()
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
                .ForMember(d => d.CustomerId, o => o.Ignore()) // سيتم ضبطه في Service
                .ForMember(d => d.CustomerName, o => o.Ignore()) // سيتم ضبطه في Service
                .ForMember(d => d.TotalReservations, o => o.MapFrom(s => s.Count()))
                .ForMember(d => d.LastReservationMonth, o => o.MapFrom(s => s.Max(r => r.CreatedDate.Month)));
        }
    }
}
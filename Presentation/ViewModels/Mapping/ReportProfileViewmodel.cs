using Application.DTOs.Report;
using AutoMapper;
using Presentation.ViewModels.Report;

namespace Presentation.ViewModels.Mapping
{

    public class ReportViewModelProfile : Profile
    {
        public ReportViewModelProfile()
        {
            // Booking Report → BookingReportViewModel
            CreateMap<BookingReportDto, BookingReportViewModel>()
                .ForMember(d => d.Month, o => o.MapFrom(s => s.Month))
                .ForMember(d => d.TotalReservations, o => o.MapFrom(s => s.TotalReservations));

            // Revenue Report → RevenueReportViewModel
            //CreateMap<RevenueReportDto, RevenueReportViewModel>()
            //    .ForMember(d => d.Month, o => o.MapFrom(s => s.Month))
            //    .ForMember(d => d.TotalRevenue, o => o.MapFrom(s => s.TotalRevenue));

            // Popular Rooms → PopularRoomViewModel
            CreateMap<PopularRoomDto, PopularRoomViewModel>()
                .ForMember(d => d.RoomType, o => o.MapFrom(s => s.RoomType))
                .ForMember(d => d.BookedCount, o => o.MapFrom(s => s.BookedCount));

            // Customer Booking Analytics → CustomerBookingAnalyticsViewModel
            CreateMap<CustomerBookingAnalyticsDto, CustomerBookingAnalyticsViewModel>()
                .ForMember(d => d.CustomerId, o => o.MapFrom(s => s.CustomerId))
                .ForMember(d => d.CustomerName, o => o.MapFrom(s => s.CustomerName))
                .ForMember(d => d.TotalReservations, o => o.MapFrom(s => s.TotalReservations))
                .ForMember(d => d.LastReservationMonth, o => o.MapFrom(s => s.LastReservationMonth));
        }
    }
}
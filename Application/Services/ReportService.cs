using Application.DTOs.Report;
using AutoMapper;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services;
public class ReportService
{
    private readonly IReportRepository _reportRepository;
    private readonly IMapper _mapper;

    public ReportService(IReportRepository reportRepository, IMapper mapper)
    {
        _reportRepository = reportRepository;
        _mapper = mapper;
    }
    public List<BookingReportDto> GetMonthlyBookingReport()
    {
        var groups = _reportRepository.GetAllReservations()
            .GroupBy(r => r.CreatedDate.Month)
            .ToList();

        return _mapper.Map<List<BookingReportDto>>(groups);
    }
    //public List<RevenueReportDto> GetMonthlyRevenueReport()
    //{
    //    var groups = _reportRepository.GetAllReservations()
    //        .GroupBy(r => r.CreatedDate.Month)
    //        .ToList();

    //    return _mapper.Map<List<RevenueReportDto>>(groups);
    //}
    public List<PopularRoomDto> GetPopularRoomsReport()
    {
        // Group by RoomId
        var groups = _reportRepository.GetAllReservations()
            .GroupBy(r => r.RoomId)
            .ToList();

        // Mapping إلى DTO
        var report = _mapper.Map<List<PopularRoomDto>>(groups);

        // Dictionary للغرف
        var roomsDict = _reportRepository.GetAllRooms()
            .ToDictionary(r => r.Id, r => r.Type.ToString());

        // نملأ RoomType بعد Mapping
        for (int i = 0; i < report.Count; i++)
        {
            var roomId = groups[i].Key; // Key هنا هو RoomId من الـ GroupBy
            report[i].RoomType = roomsDict.TryGetValue(roomId, out var type) ? type : "Unknown";
        }

        return report.OrderByDescending(r => r.BookedCount).ToList();
    }
    public List<CustomerBookingAnalyticsDto> GetCustomerBookingAnalytics()
    {
        var groups = _reportRepository.GetAllReservations()
            .GroupBy(r => r.CustomerId)
            .ToList();

        var report = _mapper.Map<List<CustomerBookingAnalyticsDto>>(groups);

        var customersDict = _reportRepository.GetAllCustomers()
            .ToDictionary(c => c.Id, c => $"{c.FirstName} {c.LastName}".Trim());

        for (int i = 0; i < report.Count; i++)
        {
            var customerId = report[i].CustomerId;
            report[i].CustomerName = customersDict.TryGetValue(customerId, out var name) && !string.IsNullOrWhiteSpace(name)
                                     ? name
                                     : "Unknown";
        }

        return report.OrderByDescending(r => r.TotalReservations).ToList();
    }

}

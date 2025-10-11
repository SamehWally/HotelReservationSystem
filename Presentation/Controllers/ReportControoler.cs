using Application.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels.Response;
using Domain.Enums;
using Presentation.ViewModels.Report;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly ReportService _reportService;
        private readonly IMapper _mapper;

        public ReportsController(ReportService reportService, IMapper mapper)
        {
            _reportService = reportService;
            _mapper = mapper;
        }

        [HttpGet("monthly-bookings")]
        public ActionResult<ResponseViewModel<IEnumerable<BookingReportViewModel>>> GetMonthlyBookingReport()
        {
            var report = _reportService.GetMonthlyBookingReport();

            if (report == null || !report.Any())
                return new ErrorResponseViewModel<IEnumerable<BookingReportViewModel>>(ErrorCode.NotFound, "No booking data found.");

            var viewModel = _mapper.Map<IEnumerable<BookingReportViewModel>>(report);
            return new SuccessResponseViewModel<IEnumerable<BookingReportViewModel>>(viewModel);
        }

        //[HttpGet("monthly-revenue")]
        //public ActionResult<ResponseViewModel<IEnumerable<RevenueReportViewModel>>> GetMonthlyRevenueReport()
        //{
        //    var report = _reportService.GetMonthlyRevenueReport();

        //    if (report == null || !report.Any())
        //        return new ErrorResponseViewModel<IEnumerable<RevenueReportViewModel>>(ErrorCode.NotFound, "No revenue data found.");

        //    var viewModel = _mapper.Map<IEnumerable<RevenueReportViewModel>>(report);
        //    return new SuccessResponseViewModel<IEnumerable<RevenueReportViewModel>>(viewModel);
        //}

        [HttpGet("popular-rooms")]
        public ActionResult<ResponseViewModel<IEnumerable<PopularRoomViewModel>>> GetPopularRoomsReport()
        {
            var report = _reportService.GetPopularRoomsReport();

            if (report == null || !report.Any())
                return new ErrorResponseViewModel<IEnumerable<PopularRoomViewModel>>(ErrorCode.NotFound, "No popular room data found.");

            var viewModel = _mapper.Map<IEnumerable<PopularRoomViewModel>>(report);
            return new SuccessResponseViewModel<IEnumerable<PopularRoomViewModel>>(viewModel);
        }

        [HttpGet("customer-analytics")]
        public ActionResult<ResponseViewModel<IEnumerable<CustomerBookingAnalyticsViewModel>>> GetCustomerBookingAnalytics()
        {
            var report = _reportService.GetCustomerBookingAnalytics();

            if (report == null || !report.Any())
                return new ErrorResponseViewModel<IEnumerable<CustomerBookingAnalyticsViewModel>>(ErrorCode.NotFound, "No customer analytics data found.");

            var viewModel = _mapper.Map<IEnumerable<CustomerBookingAnalyticsViewModel>>(report);
            return new SuccessResponseViewModel<IEnumerable<CustomerBookingAnalyticsViewModel>>(viewModel);
        }
    }
}

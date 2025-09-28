using Application.DTOs.Reservation;
using Application.Services;
using AutoMapper;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels.Response;

namespace Presentation.Controllers
{
    public class ReservationController : BaseAPIsController
    {
        private readonly ReservationService _reservationService;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;

        public ReservationController(ReservationService reservationService, IWebHostEnvironment env, IMapper mapper)
        {
            _reservationService = reservationService;
            _env = env;
            _mapper = mapper;
        }

        [HttpGet("Search")]
        public async Task<ResponseViewModel<IEnumerable<SearchReservationDto>>> Search(
            int? roomId = null, int? customerId = null,
            DateOnly? from = null, DateOnly? to = null, ReservationStatus? status = null)
        {
            var result = await _reservationService.SearchAsync(roomId, customerId, from, to, status);

            if (result == null || !result.Any())
                return new ErrorResponseViewModel<IEnumerable<SearchReservationDto>>(ErrorCode.NotFound, "No reservations found.");

            return new SuccessResponseViewModel<IEnumerable<SearchReservationDto>>(result, "Reservations fetched successfully.");
        }

        [HttpGet("{id}")]
        public async Task<ResponseViewModel<ReservationDto>> GetById(int id)
        {
            var result = await _reservationService.GetByIdAsync(id);

            if (result == null)
                return new ErrorResponseViewModel<ReservationDto>(ErrorCode.NotFound, "Reservation not found.");

            return new SuccessResponseViewModel<ReservationDto>(result, "Reservation fetched successfully.");
        }

        [HttpGet("Details/{id}")]
        public async Task<ResponseViewModel<ReservationDto>> GetDetails(int id)
        {
            var result = await _reservationService.GetDetailsAsync(id);

            if (result == null)
                return new ErrorResponseViewModel<ReservationDto>(ErrorCode.NotFound, "Reservation details not found.");

            return new SuccessResponseViewModel<ReservationDto>(result, "Reservation details fetched successfully.");
        }
    }
}

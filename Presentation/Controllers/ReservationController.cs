using Application.Services;
using AutoMapper;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPut("{id}/cancel")]
        public async Task<bool> CancelReservation(int id)
        {
            await _reservationService.CancelReservation(id);
            return true;
        }
        [HttpPut("{id}/cancel")]
        public async Task<bool> ConfirmReservation(int id)
        {
            await _reservationService.ConfirmReservation(id);
            return true;
        }
    }
}

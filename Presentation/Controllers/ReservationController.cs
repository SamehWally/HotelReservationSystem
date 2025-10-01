using Application.DTOs.Room.DTO;
using Application.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels;
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

        [HttpGet("Room Id")]
        public async Task<ResponseViewModel<IEnumerable<GetReservationByRoomIdVM>>> GetByRoom([FromQuery] GetReservationByRoomIdVM vm)
        {
            var dtoFilter = _mapper.Map<GetReservationByRoomIdDto>(vm);

            var dtoResult = await _reservationService.GetByRoomAsync(dtoFilter);

            var vms = _mapper.Map<IEnumerable<GetReservationByRoomIdVM>>(dtoResult);

            return new SuccessResponseViewModel<IEnumerable<GetReservationByRoomIdVM>>(vms);
        }
    }
}

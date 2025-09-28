using Application.DTOs.Reservation;
using Application.Services;
using AutoMapper;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels;
using Presentation.ViewModels.Reservation;
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

        [HttpPut("cancel")]
        public async Task<ResponseViewModel<bool>> CancelReservation(CancelReservationViewModel cancelReservationVM)
        {
            var dto= _mapper.Map<CancelReservationDto>(cancelReservationVM);
            var res = await _reservationService.CancelReservation(dto);
            if (res)
                return new SuccessResponseViewModel<bool>(res);
            else
                return new ErrorResponseViewModel<bool>(Domain.Enums.ErrorCode.CancelFailed);
               
        }
        [HttpPut("{confirm")]
        public async Task<ResponseViewModel<bool>> ConfirmReservation(ConfirmReservationViewModel confirmReservationVM)
        {
            var dto = _mapper.Map<ConfirmReservationDto>(confirmReservationVM);
            var res=await _reservationService.ConfirmReservation(dto);
            if (res)
                return new SuccessResponseViewModel<bool>(res);
            else
                return new ErrorResponseViewModel<bool>(Domain.Enums.ErrorCode.ConfirmFailed);
        }
    }
}

using Application.DTOs;
using Application.Services;
using AutoMapper;
using Domain.Enums;
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

        [HttpPut]
        public async Task<ResponseViewModel<UpdateReservationVM>> UpdateAsync([FromForm] UpdateReservationVM vm)
        {
            if (vm is null) return new ErrorResponseViewModel<UpdateReservationVM>(ErrorCode.InvalidInput, "Body is Required!");

            var dto = _mapper.Map<UpdateReservationDto>(vm);
            var isUpdated = await _reservationService.UpdateAsync(dto);
            if (isUpdated)
            {
                var mappedVM = _mapper.Map<UpdateReservationVM>(dto);
                return new SuccessResponseViewModel<UpdateReservationVM>(mappedVM);
            }
            return new ErrorResponseViewModel<UpdateReservationVM>(ErrorCode.UpdatedFailed);
        }
    }
}

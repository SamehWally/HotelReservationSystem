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

        [HttpPut("Date")]
        public async Task<ResponseViewModel<UpdateReservationDateVM>> UpdateDateAsync([FromForm] UpdateReservationDateVM vm)
        {
            if (vm is null) return new ErrorResponseViewModel<UpdateReservationDateVM>(ErrorCode.InvalidInput, "Body is Required!");

            var dto = _mapper.Map<UpdateReservationDateDto>(vm);
            var isUpdated = await _reservationService.UpdateDateAsync(dto);
            if (isUpdated)
            {
                var mappedVM = _mapper.Map<UpdateReservationDateVM>(dto);
                return new SuccessResponseViewModel<UpdateReservationDateVM>(mappedVM);
            }
            return new ErrorResponseViewModel<UpdateReservationDateVM>(ErrorCode.UpdatedFailed);
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

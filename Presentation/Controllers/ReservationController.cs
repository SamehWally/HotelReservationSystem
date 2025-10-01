using Application.DTOs.Reservation;
using Application.Filters;
using Application.Services;
using AutoMapper;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("GetAll")]
        public async Task<ResponseViewModel<IEnumerable<GetAllReservationViewModel>>> GetAllAsync(ReservationFilter filter)
        {
            var result = await _reservationService.GetAllReservationAsync(filter);

            if (!result.Any())
                return new ErrorResponseViewModel<IEnumerable<GetAllReservationViewModel>>(ErrorCode.ReservationNotFound, "No reservations found.");

            var mappedResult = _mapper.Map<IEnumerable<GetAllReservationViewModel>>(result);

            return new SuccessResponseViewModel<IEnumerable<GetAllReservationViewModel>>(mappedResult);
        }

        [HttpGet("GetByCustomer")]
        public async Task<ResponseViewModel<IEnumerable<GetByCustomerReservationViewModel>>> GetByCustomerAsync(
        int customerId, DateOnly? from, DateOnly? to, ReservationStatus? status = null)
        {
            var result = await _reservationService.GetByCustomerAsync(customerId, from, to, status);
          
            if (!result.Any())
                return new ErrorResponseViewModel<IEnumerable<GetByCustomerReservationViewModel>>(ErrorCode.ReservationNotFound, "No reservations found.");

            var mappedResult = _mapper.Map<IEnumerable<GetByCustomerReservationViewModel>>(result);

            return new SuccessResponseViewModel<IEnumerable<GetByCustomerReservationViewModel>>(mappedResult);
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
        [HttpPost]
        public ReservationResponse AddReservation([FromForm] AddReservationVM addReservationVM)
        {

            //var ReservationDto = new AddReservationDto
            //{

            //    Number = addReservationVM.Number,
            //    CheckIn = addReservationVM.CheckIn,
            //    CheckOut = addReservationVM.CheckOut,
            //    Status = addReservationVM.Status,
            //    RoomId = addReservationVM.RoomId,
            //    CustomerId = addReservationVM.CustomerId,
            //};
            var ReservationDto = _mapper.Map<AddReservationDto>(addReservationVM);
            var Reselt = _reservationService.addReservation(ReservationDto);
            return Reselt;

        }

        [HttpPut("cancel")]
        public async Task<ResponseViewModel<bool>> CancelReservation(CancelReservationViewModel cancelReservationVM)
        {
            var dto = _mapper.Map<CancelReservationDto>(cancelReservationVM);
            var res = await _reservationService.CancelReservation(dto);
            if (res)
                return new SuccessResponseViewModel<bool>(res);
            else
                return new ErrorResponseViewModel<bool>(Domain.Enums.ErrorCode.CancelFailed);

        }

        [HttpPut("(confirm)")]
        public async Task<ResponseViewModel<bool>> ConfirmReservation(ConfirmReservationViewModel confirmReservationVM)
        {
            var dto = _mapper.Map<ConfirmReservationDto>(confirmReservationVM);
            var res = await _reservationService.ConfirmReservation(dto);
            if (res)
                return new SuccessResponseViewModel<bool>(res);
            else
                return new ErrorResponseViewModel<bool>(Domain.Enums.ErrorCode.ConfirmFailed);
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

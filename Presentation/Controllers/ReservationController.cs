using Application.DTOs.Reservation;
using Application.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Presentation.ViewModels;
using Presentation.ViewModels.Reservation;
using Presentation.ViewModels.Response;
using System.Collections.Generic;

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
    }
}

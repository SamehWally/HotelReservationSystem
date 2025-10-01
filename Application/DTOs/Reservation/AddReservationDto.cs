using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Reservation
{
    public class AddReservationDto
    {
        public int Number { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public ReservationStatus Status { get; set; }

        public int RoomId { get; set; }
        public int CustomerId { get; set; }
      
    }
}

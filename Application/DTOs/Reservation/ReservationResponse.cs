using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Reservation
{
    public class ReservationResponse
    {
       // public int Number { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
       
        public string Message { get; set; }
        public int RoomId { get; set; }
        public int CustomerId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Reservation
{
    public class CancelReservationDto
    {
        public int ReservationId { get; set; }
        public int CustomerId { get; set; }
    }
}

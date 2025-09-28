using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Reservation
{
    public class ConfirmReservationDto
    {
        public int ReservationId { get; set; }
        public int StaffId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Reservation
{
    internal class ReservationDetailsDto : ReservationDto
    {
        public string? RoomName { get; set; }
        public string? CustomerName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Application.DTOs.Reservation
{
    public class UpdateReservationStatusDto
    {
        public int Id { get; set; }
        public ReservationStatus  Status { get; set; } 
    }
}

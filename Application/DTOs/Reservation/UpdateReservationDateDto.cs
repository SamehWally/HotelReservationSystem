using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Reservation
{
    public class UpdateReservationDateDto
    {
        public int Id { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public ReservationStatus? Status { get; set; }
    }
}

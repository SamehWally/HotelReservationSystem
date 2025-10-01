using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Reservation
{
    public class GetByCustomerReservationDto
    {
        public int Id { get; set; }

        public int Number { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public ReservationStatus Status { get; set; }

        public int RoomId { get; set; }
        public string RoomName { get; set; } = string.Empty;
        public int RoomNumber { get; set; } 

        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;

        public bool IsDeleted { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }
}

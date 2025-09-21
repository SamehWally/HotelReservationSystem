using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Models.Reservation
{
    public class Reservation:BaseModel
    {
        public int Number { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public ReservationStatus Status { get; set; }
        [ForeignKey("Room")]
        public int RoomId { get; set; }


        [ForeignKey("Customer")]
        public int CustomerId { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;
using Domain.Models.Users;
using Microsoft.EntityFrameworkCore;


namespace Domain.Models.Reservation
{
    [Index(nameof(RoomId), nameof(CheckIn))]
    [Index(nameof(RoomId), nameof(CheckOut))]
    public class Reservation:BaseModel
    {
        public int Number { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public ReservationStatus Status { get; set; }

        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public Room.Room? Room { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}

using Domain.Models.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Models.Users
{
    public class Customer : User
    {
        public DateTime? DateOfBirth { get; set; }
        public string? NationalId { get; set; }
        public ICollection<Reservation.Reservation> Reservations { get; set; } = new List<Reservation.Reservation>();
    }
}

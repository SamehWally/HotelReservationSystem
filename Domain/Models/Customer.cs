using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Customer:BaseModel
    {
        public List<Reservation.Reservation> Reservations { get; set; }
    }
}

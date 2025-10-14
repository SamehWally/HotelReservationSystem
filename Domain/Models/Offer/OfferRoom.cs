using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Offer
{
    public class OfferRoom:BaseModel
    {
        public int OfferId { get; set; }
        public Offer Offer { get; set; }

        public int RoomId { get; set; }
        public Room.Room Room { get; set; } = null!;
    }
}
